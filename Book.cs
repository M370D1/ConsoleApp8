using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        private int availableCopies;

        public int AvailableCopies
        {
            get => availableCopies;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Available copies cannot be negative.");
                availableCopies = value;
            }
        }
        public Book(string title, string author, string isbn, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            AvailableCopies = copies;
        }

        public bool Borrow()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                return true;
            }
            return false;
        }

        public void Return()
        {
            AvailableCopies++;
        }
    }
}
