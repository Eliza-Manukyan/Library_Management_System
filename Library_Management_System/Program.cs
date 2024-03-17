using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class LibraryBook
    {
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

        public LibraryBook(string title, string author, string genre, int year)
        {
            BookTitle = title;
            AuthorName = author;
            Genre = genre;
            PublicationYear = year;
        }
    }

    public sealed class BookCategory
    {
        public string CategoryTitle { get; set; }
        public string Description { get; set; }

        public BookCategory(string title, string description)
        {
            CategoryTitle = title;
            Description = description;
        }
    }

    public static class LibrarySystem
    {
        private static List<LibraryBook> libraryBooks = new List<LibraryBook>();

        public static void AddBook(LibraryBook book)
        {
            libraryBooks.Add(book);
        }

        public static void RemoveBook(string title)
        {
            libraryBooks.RemoveAll(b => b.BookTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public static void ListAllBooks()
        {
            if (libraryBooks.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                foreach (var book in libraryBooks)
                {
                    Console.WriteLine($"Title: {book.BookTitle}, Author: {book.AuthorName}, Genre: {book.Genre}, Year: {book.PublicationYear}");
                }
            }
        }
    }

    class LibraryApp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Library Management System!");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. List All Books");
                Console.WriteLine("4. Quit");

                Console.Write("Please enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("How many books do you want to add? ");
                        int count;
                        try
                        {
                            count = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < count; i++)
                            {
                                bool inputError = false;

                                Console.WriteLine($"Enter details for Book {i + 1}:");
                                Console.Write("Title: ");
                                string title = Console.ReadLine();

                                Console.Write("Author: ");
                                string author = Console.ReadLine();

                                Console.Write("Genre: ");
                                string genre = Console.ReadLine();

                                int year;
                                try
                                {
                                    Console.Write("Year: ");
                                    year = Convert.ToInt32(Console.ReadLine());

                                    LibraryBook newBook = new LibraryBook(title, author, genre, year);
                                    LibrarySystem.AddBook(newBook);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input for year. Please try again.");
                                    inputError = true;
                                }
                                catch (Exception exception)
                                {
                                    Console.WriteLine($"Unexpected error: {exception.Message}");
                                    inputError = true;
                                }

                                if (inputError)
                                {
                                    i--;
                                }
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input for book count.");
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine($"Unexpected error: {exception.Message}");
                        }
                        finally
                        {
                            Console.WriteLine("Returning to menu...");
                        }
                        break;

                    case "2":
                        Console.Write("Enter the title of the book you want to remove: ");
                        string titleToRemove = Console.ReadLine();
                        LibrarySystem.RemoveBook(titleToRemove);
                        break;

                    case "3":
                        LibrarySystem.ListAllBooks();
                        break;

                    case "4":
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}
