using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext
{
    public class ApplicationDbContextInitializer(ApplicationDbContext context, ILogger<ApplicationDbContextInitializer> logger)
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger = logger;
        private readonly ApplicationDbContext _context = context;

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }
    }
}
