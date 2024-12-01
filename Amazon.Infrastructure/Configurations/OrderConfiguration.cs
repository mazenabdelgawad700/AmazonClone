using Amazon.Core.Entities;
using Amazon.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            
            builder.ToTable("Orders");


            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)") 
                .IsRequired();

            builder.Property(o => o.Status)
           .HasConversion(
               v => v.ToString(), 
               v => (OrderStatus)Enum.Parse(typeof(OrderStatus), v) 
           );

            builder.Property(o => o.ShippingAddress)
                .IsRequired();

            builder.Property(o => o.ShippingCost)
                .IsRequired();

            builder.Property(o => o.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(o => o.TaxAmount)
                .IsRequired();

            builder.HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.CreatedDate)
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.UpdatedDate)
                .IsRequired(false);

        }
    }
}
