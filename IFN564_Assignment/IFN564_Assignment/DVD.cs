using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace IFN564_Assignment
{
    class DVD
    {

        private string title;
        private string starring;
        private string director;
        private float duration; //should be in minutes i.e. "120" mins
        private string genre;
        private string classification;
        private int date;
        private int month;
        private int year;
        private int quantity;

        public DVD(string title,
                    string starring,
                    string director,
                    float duration,
                    string genre,
                    string classification,
                    int date,
                    int month,
                    int year)
        {
            this.title = title;
            this.starring = starring;
            this.director = director;
            this.duration = duration;
            this.genre = setGenre(genre);
            this.classification = classification;
            this.date = date;
            this.month = month;
            this.year = year;
            quantity = 1;
        }
        public string getTitle()
        {
            return title;
        }
        public string getStarring()
        {
            return starring;
        }
        public string getDirector()
        {
            return director;
        }
        public float getDuration()
        {
            return duration;
        }
        public string setGenre(string gen)
        {
            return gen;
        }
        public string getGenre()
        {
            return genre;
        }
        public string getClassification()
        {
            return classification;
        }
        public string getReleaseDate()
        {
            return date.ToString() + "/" + month.ToString() + "/" + year.ToString();
        }
        public int getQuantity()
        {
            return quantity;
        }
        public void increaseQuantity()
        {
            this.quantity++;
        }
        public void decreaseQuantity()
        {
            this.quantity--;
        }
    }
}
