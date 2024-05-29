using fina.shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fina.api.Data.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired().HasColumnType("VARCHAR").HasMaxLength(80);
        builder.Property(x => x.UserId).IsRequired().HasColumnType("VARCHAR").HasMaxLength(160);
    }
}
