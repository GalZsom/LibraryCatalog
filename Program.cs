using System;
using System.Collections.Generic;

namespace LibraryCatalog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the Catalog class
            Catalog catalog = new Catalog();

            // Run the program in a loop until the user decides to exit
            while (true)
            {
                // Display the main menu options to the user
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice: ");
                // Read the user's choice and convert it to an integer
                int choice = Convert.ToInt32(Console.ReadLine());

                // Add a new book to the catalog
                if (choice == 1)
                {
                    Console.Write("Enter Title: ");
                    // Read the book title from the user
                    string title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    // Read the book author from the user
                    string author = Console.ReadLine();
                    Console.Write("Enter Publication Date (dd/mm/yyyy): ");
                    // Read the book publication date from the user and convert it to a DateTime object
                    DateTime pubDate = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter ISBN: ");
                    // Read the book ISBN from the user
                    string ISBN = Console.ReadLine();

                    Book book = new Book(title, author, pubDate, ISBN);
                    catalog.AddBook(book);
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Title or Author: ");
                    // Read the search term from the user
                    string searchTerm = Console.ReadLine();

                    // Search the catalog for books with the given title or author
                    List<Book> result = catalog.SearchBook(searchTerm);

                    if (result.Count == 0)
                    {
                        Console.WriteLine("No books found.");
                    }
                    else
                    {
                        Console.WriteLine("Results: ");
                        foreach (Book book in result)
                        {
                            Console.WriteLine(book);
                        }
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else   // If the user enters an invalid choice, display an error message
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }

    class Book
    {
        // Properties of a book
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, DateTime pubDate, string ISBN)
        {
            this.Title = title;
            this.Author = author;
            this.PublicationDate = pubDate;
            this.ISBN = ISBN;
        }

        public override string ToString()
        {
            return "Title: " + Title + ", Author: " + Author + ", Publication Date: " + PublicationDate.ToShortDateString() + ", ISBN: " + ISBN;
        }
    }

    class Catalog
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            if (IsValidISBN(book.ISBN))
            {
                books.Add(book);
                Console.WriteLine("Book added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid ISBN. Book not added.");
            }
        }

        public List<Book> SearchBook(string searchTerm)
        {
            List<Book> result = new List<Book>();
            foreach (Book book in books)
            {
                if (book.Title.Contains(searchTerm) || book.Author.Contains(searchTerm))
                {
                    result.Add(book);
                }
            }
            return result;
        }

        private bool IsValidISBN(string ISBN)
        {
            // Add ISBN validation code here.
            return true;
        }
    }
}

