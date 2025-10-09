using CafeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.ModelsConfigurations;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Number).IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Table_Number_Positive", "[Number] > 0"));
        builder.Property(x => x.CustomerId).IsRequired(false);
        
        builder.HasOne(t => t.Customer).WithOne(c => c.Table).HasForeignKey<Customer>(c => c.TableId);
    }
}