using ECommerce.Data.Enums;
using ECommerce.Models;
using Microsoft.AspNetCore.Builder;

namespace ECommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using (var applicationservies = builder.ApplicationServices.CreateScope())
            {
                var context = applicationservies.ServiceProvider.GetService<EcommerceDbContext>();
                context.Database.EnsureCreated();

                //Category
                if (!context.Categories.Any())
                {
                    var Categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name = "C1",
                            Description = "C1"
                        },
                        new Category()
                        {
                            Name = "C2",
                            Description = "C2"
                        },
                        new Category()
                        {
                            Name = "C3",
                            Description = "C3"
                        },

                    };

                    context.Categories.AddRange(Categories);
                    context.SaveChanges();
                }


                //Product
                if (!context.Products.Any())
                {
                    var Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "P1",Description="D1",Price=150,Image="/Images/1.png",
                            ProductColor = ProductColor.Red,CategoryId=1
                        },
                        new Product()
                        {
                            Name = "P2",Description="D2",Price=200,Image="/Images/4.png",
                            ProductColor = ProductColor.Green,CategoryId=2
                        },
                        new Product()
                        {
                            Name = "P3",Description="D3",Price=300,Image="/Images/11.png",
                            ProductColor = ProductColor.Yellow,CategoryId=3
                        },
                        
                    };

                    context.Products.AddRange(Products);
                    context.SaveChanges();


                }
            }
        }
    }
}
