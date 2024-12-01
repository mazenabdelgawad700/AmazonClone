using Amazon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrastructure.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Quantity)
                .IsRequired();

            builder.Property(o => o.UnitPrice)
                .IsRequired();

            builder.Property(o => o.OrderId)
                .IsRequired();

            builder.Property(o => o.ProductId)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired();


        }
    }
}
