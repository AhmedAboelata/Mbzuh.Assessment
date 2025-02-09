using System.Reflection;
using System.Text;
using Mbzuh.Assessment.BookService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Mbzuh.Assessment.BookService.Infrastructure.Persistence.DataContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options), IApplicationDbContext
    {
        private static object _lock = new();
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            string log = string.Empty;
            try
            {
                log = GenerateLogText();
            }
            catch (Exception) { }
            var result = await base.SaveChangesAsync(cancellationToken);
            try
            {
                if (!string.IsNullOrEmpty(log.ToString()))
                    SaveLogToFile(log.ToString());
            }
            catch (Exception) { }
            return result;
        }

        private string GenerateLogText()
        {
            StringBuilder log = new();
            foreach (var history in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                log.AppendLine($@"{DateTime.Now} >> {history.Metadata.Name} >> {history.State}");
                log.AppendLine($"{JsonConvert.SerializeObject(history.Entity)}");
                log.AppendLine("---------------------------------------------------------------------");
            }
            return log.ToString();
        }

        private static void SaveLogToFile(string log)
        {
            lock (_lock)
            {
                var filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
                File.AppendAllText(Path.Combine(filePath, "modificationslogs.txt"), log.ToString());
            }
        }
    }
}
