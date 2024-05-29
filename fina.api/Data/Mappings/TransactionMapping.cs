using fina.shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fina.api.Data.Mapping;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type).IsRequired().HasColumnType("SMALLINT");
        builder.Property(x => x.Amount).IsRequired().HasColumnType("MONEY");
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.PaidOrReceivedAt).IsRequired(false);
        builder.Property(x => x.UserId).IsRequired().HasColumnType("VARCHAR").HasMaxLength(160);
    }
}
