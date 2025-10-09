using CafeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.ModelsConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        builder.Property(x => x.TableId).IsRequired(false);
        
        builder.HasOne(c => c.Table).WithOne(t => t.Customer).HasForeignKey<Customer>(c => c.TableId);
    }
}