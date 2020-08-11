using System;

namespace LibraryTerminal
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public DateTime DueDate { get; set; }
        public bool CheckedOut { get; set; }

        public Book()
        {

        }

        //overloaded constructor
        public Book(string Title, string Author, Genre Genre, bool CheckedOut)
        {
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.CheckedOut = CheckedOut;

        }

        public virtual void PrintInfo()
        {

            Console.WriteLine($"Title: {Title}");
            Console.WriteLine();
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine();
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine();
        }
    }
}
