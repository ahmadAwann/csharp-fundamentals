using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Question3
{
    internal class question3
    {
        public static void Run()
        {
            Library library = new Library();

            while (true)
            {
                Console.WriteLine("\n--- Library Management System ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Update Book Status");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Display All Books");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");

                string inp = Console.ReadLine();

                switch (inp)
                {
                    case "1":
                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter Genre: ");
                        string genre = Console.ReadLine();
                        library.AddBook(title, author, genre);
                        break;

                    case "2":
                        Console.Write("Enter title or author to search: ");
                        string keyword = Console.ReadLine();
                        library.SearchBook(keyword);
                        break;

                    case "3":
                        Console.Write("Enter Book ID to update: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Select new status:");
                        Console.WriteLine("1. Available");
                        Console.WriteLine("2. Borrowed");
                        Console.WriteLine("3. Reserved");
                        Console.Write("Choice: ");
                        string sc = Console.ReadLine();

                        BookStatus status = sc switch
                        {
                            "1" => BookStatus.Available,
                            "2" => BookStatus.Borrowed,
                            "3" => BookStatus.Reserved,
                            _ => BookStatus.Available
                        };

                        library.UpdateStatus(id, status);
                        break;

                    case "4":
                        library.DeleteBook(0); // id not needed, selection handled inside
                        break;

                    case "5":
                        library.DisplayAll();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}