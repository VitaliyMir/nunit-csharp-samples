using NUnit.Framework;

namespace nunit_csharp_samples.Tests

{
    [TestFixture]
    public class LibraryManagerTests
    {
        private LibraryManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new LibraryManager();
        }

        [Test]
        public void AddBook_ShouldAddBook_WhenArticulIsUnique()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author", Articul = "123" };

            _manager.AddBook(book);

            Assert.That(_manager.Books.Contains(book), Is.True, "Book should be added when articul is unique.");
        }

        [Test]
        public void AddBook_ShouldNotAddBook_WhenArticulIsNotUnique()
        {
            var book1 = new Book { Title = "Test Book 1", Author = "Test Author 1", Articul = "123" };
            var book2 = new Book { Title = "Test Book 2", Author = "Test Author 2", Articul = "123" };

            _manager.AddBook(book1);
            _manager.AddBook(book2);

            Assert.That(_manager.Books.Count(b => b.Articul == "123"), Is.EqualTo(1), "Should not add a book with a duplicate articul.");
        }

        [Test]
        public void RemoveBook_ShouldRemoveBook_WhenBookExists()
        {
            var book = new Book { Title = "Test Book", Author = "Test Author", Articul = "123" };
            _manager.AddBook(book);

            _manager.RemoveBook(book);

            Assert.That(_manager.Books.Contains(book), Is.False, "Book should be removed.");
        }
    }
}