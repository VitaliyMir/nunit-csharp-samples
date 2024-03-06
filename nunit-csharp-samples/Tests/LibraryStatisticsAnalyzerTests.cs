using NUnit.Framework;

namespace nunit_csharp_samples.Tests;

[TestFixture]
public class LibraryStatisticsAnalyzerTests
{
    private LibraryManager _manager;
    private LibraryStatisticsAnalyzer _analyzer;

    [SetUp]
    public void Setup()
    {
        _manager = new LibraryManager();
        _analyzer = new LibraryStatisticsAnalyzer(_manager);
    }

    [Test]
    public void GetBooksByAuthor_ShouldReturnBooks_WhenAuthorMatches()
    {
        var book1 = new Book { Title = "Test Book 1", Author = "John Doe", Articul = "123" };
        var book2 = new Book { Title = "Test Book 2", Author = "Jane Doe", Articul = "124" };
        _manager.AddBook(book1);
        _manager.AddBook(book2);

        var result = _analyzer.GetBooksByAuthor("John Doe");

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result, Has.Exactly(1).Items.EqualTo(book1));
    }

    [Test]
    public void GetBookByTitle_ShouldReturnBook_WhenTitleMatches()
    {
        var expectedBook = new Book { Title = "Unique Title", Author = "Author", Articul = "123" };
        _manager.AddBook(expectedBook);

        var result = _analyzer.GetBookByTitle("Unique Title");

        Assert.That(result, Is.EqualTo(expectedBook));
    }

    [Test]
    public void GetBookByArticul_ShouldReturnBook_WhenArticulMatches()
    {
        var expectedBook = new Book { Title = "Book Title", Author = "Author", Articul = "UniqueArticul" };
        _manager.AddBook(expectedBook);

        var result = _analyzer.GetBookByArticul("UniqueArticul");

        Assert.That(result, Is.EqualTo(expectedBook));
    }
}