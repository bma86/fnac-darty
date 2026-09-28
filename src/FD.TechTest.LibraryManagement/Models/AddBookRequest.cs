namespace FD.TechTest.LibraryManagement.Models
{
    /// <summary>
    /// Une requête pour ajouter un livre à la bibliothèque
    /// </summary>
    /// <param name="title">Le titre du livre</param>
    /// <param name="author">Le nom de l'auteur</param>
    public class AddBookRequest(string title,
        string author)
    {
        public string Title { get; } = title;
        public string Author { get; } = author;
    }
}
