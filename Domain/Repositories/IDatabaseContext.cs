using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public interface IDatabaseContext
    {
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrdersItem { get; set; }

        Task<int> SaveChangesAsync();
    }
}
