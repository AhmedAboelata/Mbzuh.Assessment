using Mbzuh.Assessment.BookService.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext
{
    public class ApplicationDbContextDataSeeding(ApplicationDbContext context, ILogger<ApplicationDbContextInitializer> logger)
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;
        private readonly ApplicationDbContext _context = context;

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            if (!_context.Genre.Any())
            {
                _context.Genre.AddRange
                (
                    new Genre { Name = "Fiction" },
                    new Genre { Name = "Novel" },
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Narrative" }
                );
                await _context.SaveChangesAsync(default);
            }

            if (!_context.Book.Any())
            {
                var generIds = _context.Genre.Select(gen => gen.Id).ToList();
                Random rnd = new();

                _context.Book.AddRange
                (
                    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = 9780141439518.ToString(), PublicationYear = 1813, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = 9780141572218.ToString(), PublicationYear = 1920, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = 9780141432818.ToString(), PublicationYear = 1932, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", ISBN = 9780131432218.ToString(), PublicationYear = 1922, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "In Search of Lost Time", Author = "Marcel Proust", ISBN = 9780141432218.ToString(), PublicationYear = 1957, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "Wuthering Heights", Author = "Emily Brontë", ISBN = 9780141232218.ToString(), PublicationYear = 1988, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "Anna Karenina", Author = "Leo Tolstoy", ISBN = 9780147632218.ToString(), PublicationYear = 2000, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "Madame Bovary", Author = "Gustave Flaubert", ISBN = 9780141457218.ToString(), PublicationYear = 2010, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "War and Peace", Author = "Leo Tolstoy", ISBN = 9780149872218.ToString(), PublicationYear = 2016, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", ISBN = 9780141499218.ToString(), PublicationYear = 2003, GenreId = generIds[rnd.Next(generIds.Count)] },
                    new Book { Title = "The Brothers Karamazov", Author = "The Brothers Karamazov", ISBN = 9780145621418.ToString(), PublicationYear = 2007, GenreId = generIds[rnd.Next(generIds.Count)] }
                );
                await _context.SaveChangesAsync(default);
            }
        }
    }
}
