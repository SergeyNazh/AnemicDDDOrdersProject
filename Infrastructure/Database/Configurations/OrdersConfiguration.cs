using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    internal class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public async void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(i => i.Customer)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.CustomerId);
            builder
                .Property(i => i.OrderStatus)
                .HasConversion(
                    v => (byte)v,
                    v => (OrderStatusEnum)v
                );
        }
    }
}
