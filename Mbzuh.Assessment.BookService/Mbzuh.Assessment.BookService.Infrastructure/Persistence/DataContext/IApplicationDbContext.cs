using Mbzuh.Assessment.BookService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext
{
    public interface IApplicationDbContext
    {
        DbSet<Genre> Genre { get; }
        DbSet<Book> Book { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
