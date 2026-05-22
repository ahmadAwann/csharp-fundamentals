namespace Assignment_2.Question3
{
    internal class Library
    {
        private List<Book> books = new List<Book>();
        private int nextId = 1;

        // indexer — access books like library[0]
        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Count)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("Invalid index.");
            }
            set
            {
                if (index >= 0 && index < books.Count)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("Invalid index.");
            }
        }

        public int Count => books.Count;

        // Add
        public void AddBook(string title, string author, string genre)
        {
            Book b = new Book();
            b.BookId = nextId++;
            b.Title = title;
            b.Author = author;
            b.Genre = genre;
            b.Status = BookStatus.Available;
            books.Add(b);
            Console.WriteLine("\nBook added successfully!");
        }

        // Search
        public void SearchBook(string keyword)
        {
            var results = books.Where(b =>
                b.Title.ToLower().Contains(keyword.ToLower()) ||
                b.Author.ToLower().Contains(keyword.ToLower())).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            Console.WriteLine("\n--- Search Results ---");
            foreach (var b in results)
                DisplayBook(b);
        }

        // Update Status
        public void UpdateStatus(int id, BookStatus newStatus)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BookId == id)
                {
                    Book b = books[i];    // copy struct
                    b.Status = newStatus; // update
                    books[i] = b;         // put back
                    Console.WriteLine($"\nStatus updated to {newStatus}.");
                    return;
                }
            }
            Console.WriteLine("Book not found.");
        }

        // Delete
        public void DeleteBook(int id)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            // show numbered list
            Console.WriteLine("\nSelect book to delete:");
            var numbered = books
                .Select((b, i) => $"{i + 1}. [{b.BookId}] {b.Title} by {b.Author}")
                .ToList();
            numbered.ForEach(Console.WriteLine);

            Console.Write("Enter number: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice < 1 || choice > books.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            string name = books[choice - 1].Title;
            books.RemoveAt(choice - 1);
            Console.WriteLine($"\n'{name}' deleted successfully!");
        }

        // Display All
        public void DisplayAll()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books in library.");
                return;
            }

            Console.WriteLine("\n--- All Books ---");
            // using indexer to access books
            for (int i = 0; i < books.Count; i++)
                DisplayBook(this[i]);  // 👈 indexer used here
        }

        // helper
        private void DisplayBook(Book b)
        {
            Console.WriteLine($"ID: {b.BookId} | Title: {b.Title} | " +
                              $"Author: {b.Author} | Genre: {b.Genre} | " +
                              $"Status: {b.Status}");
        }
    }
}