using CafeApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeApp.ModelsConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

        var hireDate = builder.Property(x => x.HireDate);
        hireDate.IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Employee_HireDate", "[HireDate] < CAST(GETUTCDATE() AS date)"));
        
        var salary = builder.Property(x => x.Salary);
        salary.IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Employee_Salary", "[Salary] > 0"));
        
        var premium = builder.Property(x => x.Premium);
        premium.IsRequired();
        builder.ToTable(t => t.HasCheckConstraint("CK_Employee_Premium", "[Premium] > 0"));


    }
}