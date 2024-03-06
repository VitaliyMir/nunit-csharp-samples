/// <summary>
/// A manager for a library's collection of books.
/// </summary>
public class LibraryManager : ILibraryManager
{
    private List<Book> _books = new List<Book>();

    /// <summary>
    /// Adds a book to the library's collection.
    /// </summary>
    /// <param name="book">The book to add.</param>
    public void AddBook(Book book)
    {
        if (book != null && !_books.Contains(book))
        {
            _books.Add(book);
        }
        // TODO step 2.
    }

    /// <summary>
    /// Removes a book from the library's collection.
    /// </summary>
    /// <param name="book">The book to remove.</param>
    public void RemoveBook(Book book)
    {
        if (_books.Contains(book))
        {
            _books.Remove(book);
        }
    }
}