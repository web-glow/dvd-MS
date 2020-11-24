using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFN564_Assignment
{
    class UserInterface
    {
        private bool appStatus = true;
        private bool displayMenu = false;
        private bool displayMovie = false;
        private bool displayLogin = true;
        private bool displayBorrower = false;
        private bool displayLendMovie = false;
        private bool displayReturnMovie = false;

        private Staff staff;
        private DVDCollection DVDCollection;
        public UserInterface()
        {
            staff = new Staff();
            DVDCollection = new DVDCollection();

        }

        public void Start()
        {
            while (appStatus)
            {
                if (displayLogin)
                {
                    Login();
                }
                else if (displayMovie)
                {
                    DisplayMovies();
                }
                else if (displayMenu)
                {
                    MainMenu();
                }
                else if (displayBorrower)
                {
                    BorrowerMenu();
                }
                else if (displayLendMovie)
                {
                    LendMovie();
                }
                else if (displayReturnMovie)
                {
                    ReturnMovie();
                }
                
               
            }
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Movie DVD library\r");
            Console.WriteLine("-------------Login--------------\n");
            Console.WriteLine("\t1 - Staff ");
            Console.WriteLine("\tn - Close the app");
            Console.WriteLine("--------------------------------\n");
            Console.Write("\r\nSelect an option (1 or n) and press Enter key: ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                displayLogin = false;
                StaffLogin();
            }
            else if (userInput == "n")
            {
                appStatus = false;
            }
            else
            {
                Console.WriteLine("Please Select a Valid Input");
                Login();
                
            }
        }

        private void MainMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("----------------Staff Menu----------------\r");
            Console.WriteLine("Choose a function from the following options:");
            Console.WriteLine("\t1 - Display all Movie DVDs");
            Console.WriteLine("\t2 - Display all Movie DVDs of a specefic genre");
            Console.WriteLine("\t3 - Add a new Movie DVD");
            Console.WriteLine("\t4 - Rent out or return a Movie DVD");
            Console.WriteLine("\t5 - Logout and return to main menu");
            Console.WriteLine("\tn - Close the app");
            Console.Write("\r\nSelect an option and press Enter key: ");

            switch (Console.ReadLine())
            {
                case "n":
                    appStatus = false;
                    break;
                case "1":
                    displayMenu = false;
                    DVDCollection.displayAll();
                    //DVDCollection.displayLibrary();
                    displayMenu = true;
                    break;
                case "2":
                    displayMenu = false;
                    displayMovie = true;
                    break;
                case "3":
                    Console.WriteLine("--------Add a Movie DVD--------");
                    Console.Write("Title: ");
                    string titleInput = Console.ReadLine();
                    Console.Write("Starring: ");
                    string starringInput = Console.ReadLine();
                    Console.Write("Director: ");
                    string directorInput = Console.ReadLine();
                    Console.Write("Duration: ");
                    float durationInput = float.Parse(Console.ReadLine());
                    Console.Write("Genre: ");
                    string genreInput = Console.ReadLine();             //TODO: need to add a function, which will allow the admin to choose the genre i.e. 1 = drama, 2= blah...
                    Console.Write("Classification: ");
                    string classificationInput = Console.ReadLine();
                    Console.Write("Release Date (DD): ");
                    int dateInput = int.Parse(Console.ReadLine());
                    Console.Write("Release Month (MM): ");
                    int monthInput = int.Parse(Console.ReadLine());
                    Console.Write("Release Year (YYYY): ");
                    int yearInput = int.Parse(Console.ReadLine());
                    DVD newDVD = new DVD(titleInput, starringInput, directorInput, durationInput, genreInput, classificationInput, dateInput, monthInput, yearInput);
                    DVDCollection.insertDVD(newDVD);
                    break;
                case "4":
                    displayMenu = false;
                    displayBorrower = true;
                    break;
                case "5":
                    staff.changeLogInStatus(false);
                    displayLogin = true;
                    displayMenu = false;
                    break;
            }
        }

        public void DisplayMovies()
        {
            Console.WriteLine();
            Console.WriteLine("Console to the Movie DVD management system\r");
            Console.WriteLine("------------------------------------------\n");
            Console.WriteLine("Choose from the following genres: ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\t1 - Drama");
            Console.WriteLine("\t2 - Adventure");
            Console.WriteLine("\t3 - Family");
            Console.WriteLine("\t4 - Action");
            Console.WriteLine("\t5 - Comedy");
            Console.WriteLine("\t6 - Animated");
            Console.WriteLine("\t7 - Thriller");
            Console.WriteLine("\t8 - Other");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\tb - Go back");
            Console.WriteLine("\tn - Close the app");

            switch (Console.ReadLine())
            {
                case "1":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Drama");
                    displayMovie = true;
                    break;
                case "2":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Adventure");
                    displayMovie = true;
                    break;
                case "3":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Family");
                    displayMovie = true;
                    break;
                case "4":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Action");
                    displayMovie = true;
                    break;
                case "5":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Comedy");
                    displayMovie = true;
                    break;
                case "6":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Animated");
                    displayMovie = true;
                    break;
                case "7":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Thriller");
                    displayMovie = true;
                    break;
                case "8":
                    displayMovie = false;
                    DVDCollection.displayGenreDVD("Other");
                    displayMovie = true;
                    break;
                case "b":
                    displayMovie = false;
                    displayMenu = true;
                    break;
                case "n":
                    appStatus = false;
                    break;
                default:
                    Console.WriteLine("Please select a valid option.\r");
                    Console.WriteLine("------------------------------------------\n");
                    break;
            }

        }

        private void StaffLogin()
        {
            while (staff.getLogInStatus() != true)
            {
                Console.WriteLine("Please enter the username and password below or type b and press enter to go back.");
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.Write("Username:");
                string usernameInput = Console.ReadLine();
                if (usernameInput.CompareTo(staff.getUsername()) == 0)
                {
                    Console.Write("Password:");
                    string passwordInput = Console.ReadLine();
                    if (passwordInput.CompareTo(staff.getPassword()) == 0)
                    {
                        displayMenu = true;
                        staff.changeLogInStatus(true);
                    }
                    else if ((passwordInput.CompareTo("b") == 0))
                    {
                        displayLogin = true;
                        break;
                    }
                    else Console.WriteLine("--------Password Incorrect--------");
                }
                else if ((usernameInput.CompareTo("b") == 0))
                {
                    displayLogin = true;
                    break;
                }
                else Console.WriteLine("--------Incorrect Username!--------");
            }
        }

        public void BorrowerMenu()
        {
            Console.Clear();
            Console.WriteLine("-----------------Lend or Return a Movie-----------------\r");
            Console.WriteLine("\t1 - Lend a movie DVD");
            Console.WriteLine("\t2 - Return a movie DVD");
            Console.WriteLine("\t3 - Show existing Borrowers");
            Console.WriteLine("\tb - Go back");
            Console.WriteLine("\tn - Close the app");
            Console.Write("\r\nSelect an option and press Enter key: ");


            switch (Console.ReadLine())
            {
                case "1":
                    displayBorrower = false;
                    displayLendMovie = true;
                    break;
                case "2":
                    displayBorrower = false;
                    displayReturnMovie = true;
                    break;
                case "3":
                    displayBorrower = false;
                    DVDCollection.showExisting();
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    displayBorrower = true;
                    break;
                case "b":
                    displayMenu = true;
                    
                    break;
                case "n":
                    appStatus = false;
                    break;
            }
        }

        public void LendMovie()
        {
            Console.Clear();
            Console.WriteLine("------------------Lend a Movie------------------\r");
            Console.WriteLine("Title of the movie that customer wants to borrow:");
            string movieTitleInput = Console.ReadLine();
            //check if there is a movie with the inputed title.
            if (DVDCollection.searchMyCollection(movieTitleInput) != null)
            {
                Console.WriteLine("Customer First Name:");
                string firstNameInput = Console.ReadLine();
                Console.WriteLine("Customer Last Name:");
                string lastNameInput = Console.ReadLine();
                Console.WriteLine("Customer Contact Number:");
                string phoneInput = Console.ReadLine();

                //check if movie with that title exists. else tell inform that movie doesnt exist.
                //check if customer with those details exist -> append just the borrower's DVDArr
                //else if no customer exist -> add details with the movie to borrowerArr


                //the dvd that will be added to the borrower's DVDArr.
                DVD movieBorrowed = DVDCollection.searchMyCollection(movieTitleInput);
                Console.WriteLine(movieBorrowed.getTitle());

                Borrower customer = new Borrower(firstNameInput, lastNameInput, phoneInput, new DVD[10]);

                //check if borrower's details already exist in DVDCollection 
                if (DVDCollection.checkBorrower(customer) != 100)
                {

                    Console.WriteLine(DVDCollection.checkBorrower(customer));
                    DVDCollection.appendBorrowerMovie(DVDCollection.getBorrower(DVDCollection.checkBorrower(customer)),
                        movieTitleInput);
                }
                //else add the customer to the management system and 
                //then add the movie to that customers borrowed movies array.
                else
                {
                    DVDCollection.addBorrower(customer);
                    DVDCollection.appendBorrowerMovie(customer, movieTitleInput);
                    Console.WriteLine();
                    Console.WriteLine("Customer has been added. Press enter to continue.");
                    Console.ReadLine();
                }
                    //check if borrower exists
                    /* if (DVDCollection.checkBorrower(customer) != 100)
                    {
                        // append the movie of the borrower that exists in the datastructre.
                        DVDCollection.appendBorrowerMovie(
                            DVDCollection.getBorrower(DVDCollection.checkBorrower(customer)),
                            movieTitleInput);
                    }
                    //else add the customer to the management system and 
                    //then add the movie to that customers borrowed movies array.
                    else
                    {
                        DVDCollection.addBorrower(customer);
                        DVDCollection.appendBorrowerMovie(customer, movieTitleInput);
                    }*/
                displayLendMovie = false;
                displayBorrower = true;
            }

            /*foreach (Borrower oldCustomer in DVDCollection.getBorrowerArr()) // O(n)
            {
                if (oldCustomer.getPhoneNum().CompareTo(contactInput) == 0) //as the phone number is unique
                {
                    
                    
                    //oldCustomer.addMoreMovies(movieTitleInput);
                }
                else
                {
                    DVDCollection.addBorrower(newBorrower);
                    DVDCollection.addMovie(newBorrower, movieTitleInput);
                }
            }*/



        }

        public void ReturnMovie()
        {
            Console.Clear();
            Console.WriteLine("-----------------Return a Movie------------------\r");
            Console.WriteLine("Phone Number of the Customer:");
            string phoneNumInput = Console.ReadLine();
            //check if phone number exists.
            if (DVDCollection.checkPhoneBorrower(phoneNumInput) == 100)
            {
                Console.WriteLine("Customer with the provided phone number (" + phoneNumInput + ") doesn't exist.");
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                displayReturnMovie = false;
                displayBorrower = true;
            }
            else
            {
                Borrower existingBorrower = DVDCollection.getBorrower(DVDCollection.GetBorrowerWithPhone(phoneNumInput));
                Console.WriteLine("Title of the movie that is being returned:");
                string returnTitleInput = Console.ReadLine();
                if (DVDCollection.checkExistingDVD(existingBorrower, returnTitleInput) != null)
                {
                    DVDCollection.insertDVD(DVDCollection.checkExistingDVD(existingBorrower, returnTitleInput));
                }
                else if (DVDCollection.checkExistingDVD(existingBorrower, returnTitleInput) == null)
                {
                    Console.WriteLine("The movie with the title - " + returnTitleInput + " was not rented by " + existingBorrower);
                    Console.WriteLine("press enter to continue...");
                    Console.ReadLine();
                }
            }

            displayReturnMovie = false;
            displayBorrower = true;
        }
    }
}
