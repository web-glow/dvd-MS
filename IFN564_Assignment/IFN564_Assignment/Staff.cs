using System;
using System.Collections.Generic;
using System.Text;

namespace IFN564_Assignment
{
    class Staff
    {
        private string username;
        private string password;
        private bool loggedIn = false;
        public Staff()
        {
            this.username = "admin";
            this.password = "admin";
        }

        public void changeLogInStatus(bool x)
        {
            loggedIn = x;
        }
        public bool getLogInStatus()
        {
            return loggedIn;
        }

        public string getUsername()
        {
            return username;
        }
        public string getPassword()
        {
            return password;
        }



    }
}
