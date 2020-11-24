using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using System.Threading;

namespace IFN564_Assignment
{
    class Borrower
    {
        private string firstName;
        private string lastName;
        private string phoneNum; 
        //array of DVDs that the borrower rents or borrowes.
        private DVD[] moviesArray;

        //counter for movies borrowerd by the customer
        private int borrowedMoviesCounter; 
        

        public Borrower(string firstName, 
                        string lastName, 
                        string phoneNum,
                        DVD[] movies)
        {
            /*moviesArray = new DVD[10]*/;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNum = phoneNum;
            this.moviesArray = movies;
            //The max ammount of DVDs that a borrower can borrow is 11 (i.e. 0 to 10).
            
            //A counter for the above array.
            borrowedMoviesCounter = 0;
        }

        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getPhoneNum()
        {
            return phoneNum;
        }

        /**
         * Adds the dvd to the borrower's array of borrowed movies.
         */
        public void addRentedMovie(DVD dvd)
        {
            //check if the array is between 0 and 10, and the parameter is not null.
            if (borrowedMoviesCounter >= 0 && borrowedMoviesCounter < 10 && dvd != null)
            {

                //add the dvd to the borrowers movies array.
                moviesArray[borrowedMoviesCounter] = dvd;
                borrowedMoviesCounter++;

            }
        }

        public void displayBorrowedMovie()
        {
                for (int i = 0; i < moviesArray.Length; i++)
                {
                    if (moviesArray[i] != null)
                    {
                        Console.WriteLine(moviesArray[i].getTitle());
                    }
                }
        }

        //removes dvd from the borrowers array and returns the same DVD
        public DVD removeDVD(string movieTitle)
        {
            DVD result = null;
            for (int i = 0; i < moviesArray.Length; i++)
            {
                if (moviesArray[i] != null &&
                    moviesArray[i].getTitle().CompareTo(movieTitle) == 0)
                {
                    // this movie is never put into result hence it doesn't work properly.
                    result = moviesArray[i];
                    moviesArray[i] = null;
                    borrowedMoviesCounter--;
                } 
            }
            return result;

        }
    }
}
