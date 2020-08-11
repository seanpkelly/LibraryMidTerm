using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace LibraryTerminal
{
    public class Library : Book
    {
        public List<Book> Books { get; set; }     

        public Library()
        {
            Books = new List<Book>()
            {
                new Book("The Old Man and the Sea", "Ernest Hemingway", Genre.Fiction, false),
                new Book("Bluets", "Maggie Nelson", Genre.Poetry, false),
                new Book("Bough Down", "Karen Green", Genre.Poetry, false),
                new Book("Men Without Women", "Haruki Murakami", Genre.Fiction, false),
                new Book("Streetfight: Handbook for an Urban Revolution", "Janette Sadik-Khan", Genre.NonFiction, false),
                new Book("The Odyssey", "Homer", Genre.Fiction, false),
                new Book("The Language of Cities", "Deyan Sudjic", Genre.NonFiction, false),
                new Book("Pinball, 1973", "Haruki Murakami", Genre.Fiction, false),
                new Book("Play It As It Lays", "Joan Didion", Genre.Fiction, false),
                new Book("The Virgin Suicides", "Jeffery Eugenides", Genre.Fiction, false),
                new Book("The Metamorphosis", "Franz Kafka", Genre.Fiction, false),
                new Book("The Color of Law: A Forgotten History of How Our Government Segregated America", "Richard Rothstein", Genre.NonFiction, false),
                new Book("The Things They Carried", "Tim O'Brien", Genre.Fiction, false),
                new Book("The Templars", "Dan Jones", Genre.NonFiction, false),
                new Book("In the Heart of the Sea", "Nathaniel Philbrick", Genre.NonFiction,  false),
                new Book("A Time of Gifts", "Patrick Leigh Fermor", Genre.Fantasy, false),
                new Book("The Road Less Traveled", "Robert Frost", Genre.Poetry, false)
            };
        }
        public void PrintWholeList()
        {
            PrintBooks();
            Console.WriteLine();

        }
        public void DisplayAvailableBooks()
        {
  
            foreach (Book book in Books)
            {
                if (CheckedOut == false)
                {
                    Console.WriteLine(book.CheckedOut);
                }
            }
        }

        public void GetTitles()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book.Title);
            }
        }

        public void CheckOutBookByGenre()
        {
            Genre selectedGenre = 0;

            Console.WriteLine("\nAh so you would like to check out a book, great! \nPlease input your choice: ");
            string genre = Console.ReadLine().ToLower().Trim();


            if (genre == "scifi")
            {
                selectedGenre = Genre.SciFi;
            }
            if (genre == "romance")
            {
                selectedGenre = Genre.Romance;
            }
            if (genre == "action")
            {
                selectedGenre = Genre.Action;
            }
            if (genre == "fantasy")
            {
                selectedGenre = Genre.Fantasy;
            }
            if (genre == "biography")
            {
                selectedGenre = Genre.Biography;
            }
            if (genre == "nonfiction")
            {
                selectedGenre = Genre.NonFiction;
            }
            if (genre == "mystery")
            {
                selectedGenre = Genre.Mystery;
            }
            if (genre == "thriller")
            {
                selectedGenre = Genre.Thriller;
            }
            if (genre == "poetry")
            {
                selectedGenre = Genre.Poetry;
            }
            if (genre == "fiction")
            {
                selectedGenre = Genre.Fiction;
            }

            foreach (Book book in Books)
            {
                if (book.Genre == selectedGenre)

                {
                    if (book.CheckedOut == false)
                    {
                        Console.WriteLine("Perfect, books of that genre is available");
                        Console.WriteLine("Would you like to check out one of the books out? y/n");
                        string input = Console.ReadLine();
                        if (input == "y")
                        {
                            book.CheckedOut = true;
                            book.DueDate = DateTime.Now.AddDays(14);
                            break;
                        }
                    }
                }
            }
        }
        public void CheckOutBookByAuthor()
        {
            Console.WriteLine("\nAh so you would like to check out a book by a specific author, great!");
           
            Console.WriteLine("\nPlease input your choice: ");
            string author = Console.ReadLine().ToLower().Trim();

            foreach (Book book in Books)
            {
                if (book.Author.ToLower().Contains(author))
                {

                    if (book.CheckedOut == false)
                    {
                        Console.WriteLine("Perfect, their book is available");
                        Console.WriteLine("Would you like to check the book out? y/n");
                        string input = Console.ReadLine();
                        if (input == "y")
                        {
                            book.CheckedOut = true;
                            book.DueDate = DateTime.Now.AddDays(14);
                            CheckOutBookByTitle();
                            break;
                        }
                    }
                }
            }
        }
        public void CheckOutBookByTitle()
        {

            Console.WriteLine("\nAh so you would like to check out a book, great! \nPlease input your choice: ");
            string title = Console.ReadLine().ToLower().Trim();

            foreach (Book book in Books)
            {
                if (book.Title.ToLower().Contains(title))
                {
                    if (book.CheckedOut == false)
                    {
                        Console.WriteLine("\nPerfect, that book is available");
                        Console.WriteLine("Would you like to check the book out? y/n");
                        string input = Console.ReadLine();
                        if (input == "y")
                        {
                            book.CheckedOut = true;
                            book.DueDate = DateTime.Now.AddDays(14);
                            break;
                        }
                    }
                }
            }


            Console.Write("\nAlright, the current date and time is : \n");
            DateTime now = DateTime.Now;
            Console.WriteLine(now);

            DateTime duedate = DateTime.Now.AddDays(14);
            Console.WriteLine("\nThat means this book is due: " + duedate+ "\n");
            Console.WriteLine("Thanks, enjoy the book.");
        }

        public void DisplayAuthors()
        {
            foreach (Book book in Books)
            {
                Console.WriteLine(book.Author);
            }
        }

        public void DisplayBooksByAuthor()
        {
            Console.WriteLine("\nAh so you would like to check out a book, great! \nPlease input your choice: ");
            string author = Console.ReadLine().ToLower().Trim();

            foreach (Book book in Books)
            {
                if (book.Author.ToLower().Contains(author))
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        public void PrintBooks()
        {

            for (int i = 0; i < Books.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Books[i].Title} written by {Books[i].Author}");
            }
        }

        public static void WhichGenre()
        {
            Genre genreValue = Genre.Romance;
            string enumValue = genreValue.ToString();

            Console.WriteLine("Here are our genre's of books to choose from: \n");
            
            for (Genre g = Genre.SciFi;
            g <= Genre.Fiction; g++)
            {
                string value = g.ToString();
                Console.WriteLine(value);
            }
        }
        public static void GetUserSelection(List<Library> Title)
        {
            Library output;
            int pick;
            while (true)
            {
                Console.WriteLine($"Which book would you like to know more about? { Title.Count - 1} ");
                string input = Console.ReadLine();
                try
                {

                    pick = int.Parse(input);
                    if (pick >= 0 && pick < Title.Count)
                    {
                        output = Title[pick];
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"That is not a valid input, please input a number between 0 and {Title.Count - 1}");

                        Console.WriteLine("Lets go again");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("That wasn't an integer let's try again.");
                    continue;
                }
            }
        }
    }
}
