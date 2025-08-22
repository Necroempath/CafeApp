using CafeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.ModelsConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Amount).IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Payment_Amount_Positive", "[Amount] > 0"));
        
        builder.Property(x => x.PaymentTime).IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Payment_Time", "[PaymentTime] < GETUTCDATE()"));
        
        builder.HasOne(p => p.Order).WithOne(o => o.Payment).HasForeignKey<Payment>(p => p.OrderId);
    }
}