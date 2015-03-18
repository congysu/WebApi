using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    using System.Data.Entity;

    public class ProductsContext : DbContext
    {
        public ProductsContext()
            : base("name=ProductsContext")
        {
            Database.SetInitializer(new ProductsInitializer());
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class ProductsInitializer : DropCreateDatabaseAlways<ProductsContext>
    {
        protected override void Seed(ProductsContext context)
        {
            var sup = new Supplier { Id = 1, Name = "sup1", Products = new Collection<Product>() };
            var products = new List<Product>();
            products.Add(new Product {Id =10, Name = "prod1", Supplier = sup, SupplierId = 1});
            products.Add(new Product { Id = 11, Name = "prod2", Supplier = sup, SupplierId = 1 });

            context.Products.AddRange(products);

            base.Seed(context);
        }
    }
}