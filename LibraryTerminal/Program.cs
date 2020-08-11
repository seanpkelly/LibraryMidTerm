using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Net.Http;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Console.WriteLine();
            MenuSelection(library);
            
            ContinueMenu(library);

        }
        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("1.) View our Book List");
            Console.WriteLine("2.) Search by Title");
            Console.WriteLine("3.) Search by Author");
            Console.WriteLine("4.) Search by Genre");
            Console.WriteLine("5.) Exit the Library\n");


        }

        public static void MenuSelection(Library library)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------");
            Console.WriteLine("|Welcome to the Library|");
            Console.WriteLine("------------------------");
            Console.WriteLine("Press enter to continue");
            Console.WriteLine(",.,.,.,.,.,.,.,.,.,.,.,.\n");
            Console.ReadKey();
            DisplayMenu();

            

            switch (GetUserInput("Which way would you like to choose your book? \n"))
            {
  
                case "1":

                    Console.WriteLine("Here is our entire list of books: \n");
                    Console.WriteLine("---------------------------------\n");
                    //printing the entire book list
                    library.PrintWholeList();

                    break;
                case "2":
                    Console.WriteLine("Here are our books by title: \n");
                    Console.WriteLine("---------------------------\n");
                    //Console.WriteLine("Please type out the name of your choice\n");
                    //Send User to the search by Title method
                    library.GetTitles();

                    library.CheckOutBookByTitle();

                    break;
                case "3":
                    Console.WriteLine("Here are our books by author: \n");
                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("Please type out the name of your choice\n");
                    //Send user to the search by author method
                    Console.WriteLine("Here are the authors we feature: \n");
                    library.DisplayAuthors();
                    Console.WriteLine("Here are those said authors and their corresponding works: \n");
                    library.PrintBooks();

                    library.CheckOutBookByAuthor();

                    break;
                case "4":
                    //send user to the search by genre method
                    Console.WriteLine("Here are our books by genre: \n");
                    Console.WriteLine("---------------------------\n");
                    Console.WriteLine("Please type out the name of your choice\n");
                    Library.WhichGenre();
                    //We need to use get titles after they pick which genre in some way
                    //Library.GetTitles();
                    library.CheckOutBookByGenre();

                    break;
                case "5":
                    Console.WriteLine("Thanks for visiting us today!\n");
                    Console.WriteLine("Please wear a mask and socially distance yourself!");

                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Sorry, we didn't get that. Try Again!\n");
                    MenuSelection(library);
                    break;
            }
        }

        public static void ContinueMenu(Library library) 
        {

            bool programStart = true;
            while (programStart)
            {
                Console.WriteLine("Would you like to contine? y/n\n");

                string responseLast = Console.ReadLine().ToLower().Trim();

                if (responseLast == "y")
                {
                    //Console.WriteLine($"Would like to continue? \n");
                    MenuSelection(library);

                    programStart = true;
                    break;
                }

                else if (responseLast == "n" || responseLast == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("\nThanks for visiting us today!\n");
                    Console.WriteLine("Please wear a mask and socially distance yourself!\n");
                    
                    programStart = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Continue? y/n?");
                }
            }
        }
    }
}
