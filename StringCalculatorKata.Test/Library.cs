using System.Collections.Generic;

namespace LibraryApp
{
    public class Library
    {
        private readonly List<string> _books;
        private readonly HashSet<string> _reservedBooks;

        public Library(List<string> books)
        {
            _books = books ?? new List<string>();
            _reservedBooks = new HashSet<string>();
        }

        public List<string> GetAvailableBooks()
        {
            var availableBooks = new List<string>();
            foreach (var book in _books)
            {
                if (!_reservedBooks.Contains(book))
                {
                    availableBooks.Add(book);
                }
            }
            return availableBooks;
        }

        public bool ReserveBook(string bookName)
        {
            if (_books.Contains(bookName) && !_reservedBooks.Contains(bookName))
            {
                _reservedBooks.Add(bookName);
                return true;
            }
            return false; // Si le livre n'existe pas ou est déjà réservé
        }

        public bool ReturnBook(string bookName)
        {
            if (_reservedBooks.Contains(bookName))
            {
                _reservedBooks.Remove(bookName);
                return true;
            }
            return false; // Si le livre n'était pas réservé
        }
    }
}
