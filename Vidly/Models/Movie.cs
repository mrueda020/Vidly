using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { set; get; }
        public string name { set; get; }

        private int year;

        public void setYear(int year)
        {
            this.year = year;
        }

        public int getYear()
        {
            return this.year;
        }

    }
}