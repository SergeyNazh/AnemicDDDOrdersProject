using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder
                .HasOne(i => i.Order)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(i => i.OrderId);
            builder
                .HasOne(i => i.Product)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
