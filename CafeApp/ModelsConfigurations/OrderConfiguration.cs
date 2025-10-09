using CafeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.ModelsConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.ToTable((t) =>
        {
            t.HasCheckConstraint("CK_Product_Cost_Positive", "[Cost] > 0");
            t.HasCheckConstraint("CK_Order_CreatedAt", "[CreatedAt] < GETUTCDATE()");
            t.HasCheckConstraint("CK_Order_CompletedAt",
                "[CompletedAt] < GETUTCDATE() AND [CompletedAt] > [CreatedAt]");
        });
        
        builder.Property(o => o.Cost).IsRequired();
        
        builder.Property(x => x.CreatedAt).IsRequired();
        
        builder.Property(o => o.CompletedAt).IsRequired(false);
        
        builder.Property(x => x.IsCompleted).IsRequired();
    
        builder.HasOne(o => o.ServicedBy).WithMany(e => e.Orders).HasForeignKey(o => o.EmployeeId);
        
        builder.HasOne(o => o.OrderedBy).WithMany(t => t.Orders).HasForeignKey(o => o.TableId);
        
        builder.HasOne(o => o.Payment).WithOne(p => p.Order).HasForeignKey<Order>(o => o.PaymentId).IsRequired(false);
    }
}