using Mbzuh.Assessment.BookService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mbzuh.Assessment.BookService.Infrastructure.Persistence.EntityConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Author).HasMaxLength(200).IsRequired();
            builder.Property(t => t.ISBN).HasMaxLength(13).IsRequired();
            builder.Property(t => t.PublicationYear).IsRequired();
            builder.HasOne(t => t.Genre).WithMany(c => c.Books).HasForeignKey(ci => ci.GenreId);
        }
    }
}
