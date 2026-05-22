namespace Assignment_2.Question3
{
    internal struct Book
    {
        // private fields
        private int _bookId;
        private string _title;
        private string _author;
        private string _genre;
        private BookStatus _status;

        // properties
        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _title = value;
                else
                    Console.WriteLine("Title cannot be empty.");
            }
        }

        public string Author
        {
            get { return _author; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _author = value;
                else
                    Console.WriteLine("Author cannot be empty.");
            }
        }

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        public BookStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}