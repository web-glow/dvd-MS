
using System;
using System.Collections.Generic;

namespace IFN564_Assignment
{
    class DVDCollection
    {
        private BSTree binaryDVDTree;
        private Borrower[] borrowersArr;
        //all the customers who will/have borrowed is stored in this.
        //private Borrower[] borrowerArr;

        //a count keeper for the borrowerArr
        private int borrowersCount;
        private QuickSort sorter;
        public DVDCollection() 
        {
            borrowersArr = new Borrower[10];
            binaryDVDTree = new BSTree();
            //when the DVDCollection is created in UserInterface, it will have only one borrower array:

            borrowersCount = 0;
           
            sorter = new QuickSort();
            insertDVD(new DVD("George of the jungle", "james bond", "chris nolen", 140, "Drama", "General", 29, 1, 2010));
            insertDVD(new DVD("Avengers", "Robert Downy Jr.", "James bond", 180, "Thriller", "General", 22, 2, 2012));
            insertDVD(new DVD("Tenet", "james bond", "chris nolen", 140, "Thriller", "General", 29, 1, 2010));
            insertDVD(new DVD("George of the jungle", "james bond", "chris nolen", 140, "Drama", "General", 29, 1, 2010));
            insertDVD(new DVD("Intersteller", "james bond", "chris nolen", 140, "Drama", "General", 29, 1, 2010));

        }

        public DVD searchMyCollection(string movieTitle)
        {
            return binaryDVDTree.search(movieTitle);
        }
        public void insertDVD(DVD dvd)
        {
            binaryDVDTree.Insert(dvd);
            
        }
        public void displayAll()
        {
            binaryDVDTree.InOrderTraverse();
        }
        public void displayGenreDVD(String gen)
        {
            Console.Clear();
            binaryDVDTree.selectGenre(gen);
            binaryDVDTree.changeGenreStatus(true);
            Console.WriteLine();
            Console.WriteLine("Genre selected: " + gen);
            binaryDVDTree.InOrderTraverse();
            binaryDVDTree.changeGenreStatus(false);
        }
        public void addBorrower(Borrower b)
        {
            //add the borrower to the management system array.

            if (borrowersArr[borrowersCount] == null)
            {
                borrowersArr[borrowersCount] = b;
                borrowersCount++;
            }
        }
        /**
         * A method to append a borrower's array of borrowed movies. 
         * This doesn't increase or decrease the borrowers of the Management system.
         * 
         * Asuming that a customer cannot borrow the same movie more than once.
         */
        public void appendBorrowerMovie(Borrower b, string movieTitle)
        {
            //searches if the movie is available in the management system.
            DVD searchedDVD = binaryDVDTree.search(movieTitle);   
            //if the seachedDVD is not null then add the movie to the borrower's array of movies.
            if (searchedDVD != null)
            {
                //check if only 1 copy of the movie is left
                if (searchedDVD.getQuantity() == 1)
                {
                    //delete the movie from the collection
                    binaryDVDTree.Delete(searchedDVD);
                }
                //check if more than 1 copy is available
                else if (searchedDVD.getQuantity() > 1)
                {
                    //decrease the quantity of that movie.
                    searchedDVD.decreaseQuantity();
                }
                b.addRentedMovie(searchedDVD);
                

            }
        }

        public Borrower getBorrower(int i)
        {
            return borrowersArr[i];
        }
        //checks if the borrower exists in the borrowersQueue.
        //linear check. Big-O = O(n)
        //100 = doesn't exist

        //if it returns 100 then the borrower doesn't exists in the array
        public int checkBorrower(Borrower b)
        {
            int result = 100;
            for (int i = 0; i < borrowersArr.Length; i++)
            {
                if (borrowersArr[i] != null)
                {
                    if (b.getPhoneNum().CompareTo(borrowersArr[i].getPhoneNum()) == 0)
                    {
                        result = i;
                    }
                }
            }
            return result;
            


           /* if (binarySearch(borrowerArr, b.getPhoneNum()) != 100)
            {
                result = binarySearch(borrowerArr, b.getPhoneNum());
            }
            return result;*/
        }
        //if it returns 100 then customer with a phone number 'phone' doesn't exists.

        public int checkPhoneBorrower(string phone)
        {
            int result = 100;
            for (int i = 0; i < borrowersArr.Length; i++)
            {
                if (borrowersArr[i] != null)
                {
                    if (phone.CompareTo(borrowersArr[i].getPhoneNum()) == 0)
                    {
                        result = i;
                    }
                }
            }
            return result;



            /* if (binarySearch(borrowerArr, b.getPhoneNum()) != 100)
             {
                 result = binarySearch(borrowerArr, b.getPhoneNum());
             }
             return result;*/
        }

        public int GetBorrowerWithPhone(string phone)
        {
            int result = 100;
            for (int i = 0; i < borrowersCount; i++)
            {
                if (phone.CompareTo(borrowersArr[i].getPhoneNum()) == 0)
                {
                    result = i;
                }
            }
            return result;
        }

        //Binary Search for finding a borrower
        //not working properly (some bug unable to solve)
        /* public int binarySearch(Borrower[] arr, string phoneNum) 
         {
             int min = 0;
             int max = borrowerCounter; //should be 10

             while (min <= max)
             {
                 int mid = (min + max)/2;
                 if (arr[mid] != null)
                 {
                     if (phoneNum.CompareTo(arr[mid].getPhoneNum()) == 0)
                         return mid;
                     else if (phoneNum.CompareTo(arr[mid].getPhoneNum()) < 0)
                         max = mid - 1;
                     else
                         min = mid + 1;
                 }
                 else return 100;
             }
             //return 100 if 
             return 100;
         }*/
        public void showExisting()
        {
            Console.WriteLine("Existing customers with the movies that they have borrowed");
            
            foreach (Borrower b in borrowersArr)
            {
                if (b != null)
                {
                    Console.WriteLine("-------------------------");
                    Console.Write("Name: ");
                    Console.WriteLine(b.getFirstName() + " " + b.getLastName());
                    Console.Write("Contact Number: ");
                    Console.WriteLine(b.getPhoneNum());
                    Console.WriteLine();
                    Console.WriteLine("Movies currently borrowed:");
                    b.displayBorrowedMovie();
                }
            }
        }

        public DVD checkExistingDVD(Borrower b, string movieTitle)
        {
           return b.removeDVD(movieTitle);
        }

    }
}
