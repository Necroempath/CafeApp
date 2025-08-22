using CafeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.ModelsConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        var createdAt = builder.Property(x => x.CreatedAt);
        createdAt.IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Order_CreatedAt", "[CreatedAt] < GETUTCDATE()"));

        builder.Property(x => x.IsCompleted).IsRequired();

        builder.Property(x => x.TableNumber).IsRequired();

        builder.HasOne(o => o.CreatedBy).WithMany(e => e.Orders).HasForeignKey(o => o.EmployeeId);
        
        builder.HasOne(o => o.OrderedBy).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
        
        builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Order>(o => o.PaymentId);
    }
}