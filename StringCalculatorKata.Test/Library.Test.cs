using NUnit.Framework;
using System.Collections.Generic;

namespace LibraryApp
{
    [TestFixture]
    public class LibraryTests
    {
        [Test]
        public void Library_InitializedWithBooks_ShouldContainBooks()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2", "Book3" };
            var library = new Library(books);

            // Act
            var availableBooks = library.GetAvailableBooks();

            // Assert
            CollectionAssert.AreEquivalent(books, availableBooks);
        }

        [Test]
        public void ReserveBook_WhenBookIsAvailable_ShouldReserveBook()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2", "Book3" };
            var library = new Library(books);

            // Act
            var isReserved = library.ReserveBook("Book1");

            // Assert
            Assert.IsTrue(isReserved);
            CollectionAssert.DoesNotContain(library.GetAvailableBooks(), "Book1");
        }

        [Test]
        public void ReserveBook_WhenBookIsAlreadyReserved_ShouldReturnFalse()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2", "Book3" };
            var library = new Library(books);
            library.ReserveBook("Book1");

            // Act
            var isReservedAgain = library.ReserveBook("Book1");

            // Assert
            Assert.IsFalse(isReservedAgain);
        }
        [Test]
        public void ReserveBook_WhenBookDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2", "Book3" };
            var library = new Library(books);

            // Act
            var isReserved = library.ReserveBook("BookNotFound");

            // Assert
            Assert.IsFalse(isReserved);
        }

        [Test]
        public void ReturnBook_WhenBookDoesNotExist_ShouldReturnFalse()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2", "Book3" };
            var library = new Library(books);

            // Act
            var isReturned = library.ReturnBook("BookNotFound");

            // Assert
            Assert.IsFalse(isReturned);
        }

        [Test]
        public void ReturnBook_WhenBookIsReserved_ShouldMakeItAvailableAgain()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2", "Book3" };
            var library = new Library(books);
            library.ReserveBook("Book1");

            // Act
            var isReturned = library.ReturnBook("Book1");

            // Assert
            Assert.IsTrue(isReturned);
            CollectionAssert.Contains(library.GetAvailableBooks(), "Book1");
        }
        [Test]
        public void ReserveBook_WhenSameUserTriesToReserveTwice_ShouldReturnFalse()
        {
            // Arrange
            var books = new List<string> { "Book1" };
            var library = new Library(books);

            // Act
            library.ReserveBook("Book1"); // First reservation
            var secondAttempt = library.ReserveBook("Book1"); // Second attempt

            // Assert
            Assert.IsFalse(secondAttempt);
        }
        [Test]
        public void ReturnBook_WhenBookIsNotReserved_ShouldReturnFalse()
        {
            // Arrange
            var books = new List<string> { "Book1", "Book2" };
            var library = new Library(books);

            // Act
            var isReturned = library.ReturnBook("Book1");

            // Assert
            Assert.IsFalse(isReturned);
        }
        [Test]
        public void ReserveBook_AfterReturningBook_ShouldAllowReservation()
        {
            // Arrange
            var books = new List<string> { "Book1" };
            var library = new Library(books);
            library.ReserveBook("Book1");
            library.ReturnBook("Book1");

            // Act
            var isReservedAgain = library.ReserveBook("Book1");

            // Assert
            Assert.IsTrue(isReservedAgain);
        }


    }
}
