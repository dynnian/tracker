namespace Tracker.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; private set; }

        // The title of the book.
        public string Title { get; private set; }

        // A brief description of the book.
        public string? Description { get; private set; }

        // The author of the book.
        public string? Author { get; private set; }

        // The publisher of the book.
        public string? Publisher { get; private set; }

        // The ISBN of the book.
        public string? Isbn { get; private set; }

        // The URL of the book.
        public string? Url { get; private set; }

        // The number of pages in the book.
        public int? Pages { get; private set; }

        // The cover image of the book.
        public Media? Cover { get; private set; }

        // The date the book was created in the system.
        public DateTime CreatedAt { get; private set; }

        // The ID of the user who created the book
        public string CreatedBy { get; private set; }

        // The date the book was last updated in the system.
        public DateTime? UpdatedAt { get; private set; }

        // The ID of the user who last updated the book
        public string? UpdatedBy { get; private set; }

        private Book() { }

        public Book(
            string title,
            string createdBy,
            string? description = null,
            string? author = null,
            string? publisher = null,
            string? isbn = null,
            string? url = null,
            int? pages = null,
            Media? cover = null
        )
        {
            Id = Guid.NewGuid();
            Title = !string.IsNullOrWhiteSpace(title)
                ? title
                : throw new ArgumentNullException(nameof(title), "Book title cannot be empty.");
            Description = description;
            Author = author;
            Publisher = publisher;
            Isbn = isbn;
            Url = url;
            Pages = pages;
            Cover = cover;
            CreatedAt = DateTime.Now;
            CreatedBy = !string.IsNullOrWhiteSpace(createdBy)
                ? createdBy
                : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be empty.");
        }

        public void UpdateDetails(
            string updatedBy,
            string? title = null,
            string? description = null,
            string? author = null,
            string? publisher = null,
            string? isbn = null,
            string? url = null,
            int? pages = null,
            Media? cover = null)
        {
            if (new object?[] { title, description, author, publisher, isbn, url, pages, cover }.All(p => p == null))
                throw new ArgumentException("At least one parameter must be provided.");

            Title = title ?? Title;
            Description = description ?? Description;
            Author = author ?? Author;
            Publisher = publisher ?? Publisher;
            Isbn = isbn ?? Isbn;
            Url = url ?? Url;
            Pages = pages ?? Pages;
            Cover = cover ?? Cover;
            UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy)
                ? updatedBy
                : throw new ArgumentNullException(nameof(updatedBy), "UpdatedBy cannot be empty.");
            UpdatedAt = DateTime.Now;
        }

        public static Book Load(
            Guid id,
            string title,
            string createdBy,
            DateTime createdAt,
            string? description = null,
            string? author = null,
            string? publisher = null,
            string? isbn = null,
            string? url = null,
            int? pages = null,
            Media? cover = null,
            DateTime? updatedAt = null,
            string? updatedBy = null)
        {
            return new Book
            {
                Id = id,
                Title = title,
                Description = description,
                Author = author,
                Publisher = publisher,
                Isbn = isbn,
                Url = url,
                Pages = pages,
                Cover = cover,
                CreatedAt = createdAt,
                CreatedBy = createdBy,
                UpdatedAt = updatedAt,
                UpdatedBy = updatedBy
            };
        }
    }
}