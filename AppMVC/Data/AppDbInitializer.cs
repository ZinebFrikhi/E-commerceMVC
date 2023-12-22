using AppMVC.Data.Static;
using AppMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace AppMVC.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Title = "Category 1",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first category"
                        },
                        new Category()
                        {
                            Title = "Category 2",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second category"
                        },
                        new Category()
                        {
                            Title = "Category 3",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the third category"
                        },
                        new Category()
                        {
                            Title = "Category 4",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the fourth category"
                        }
                    });
                    context.SaveChanges();
                }
                //Suppliers
                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new List<Supplier>()
                    {
                        new Supplier()
                        {
                            Name = "Supplier 1",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first Supplier"
                        },
                        new Supplier()
                        {
                            Name = "Supplier 2",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the second Supplier"
                        },
                        new Supplier()
                        {
                            Name = "Supplier 3",
                            ImageUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the third Supplier"
                        }
                    });
                    context.SaveChanges();
                }
                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Title = "Laptop UltraBook Pro",
                            Description = "Performances exceptionnelles dans un format ultraléger.",
                            Price = 1299.99,
                            ImageUrl = "/images/p1.jpg",
                            createdAt = DateTime.Now.AddDays(-2),
                            CategoryId = 1,
                            SupplierId = 1
                        },
                        new Product()
                        {
                            Title = "Disque DUR 3080",
                            Description = "Disque dur externe 1T SSD",
                            Price = 699.99,
                            ImageUrl = "/images/p2.jpg",
                            createdAt = DateTime.Now.AddDays(-5),
                            CategoryId = 2,
                            SupplierId = 2
                        },
                        new Product()
                        {
                            Title = "Clavier Mécanique RGB",
                            Description = "Rétroéclairage personnalisable pour une expérience de frappe optimale.",
                            Price = 99.99,
                            ImageUrl = "/images/p3.jpg",
                            createdAt = DateTime.Now.AddDays(-2),
                            CategoryId = 3,
                            SupplierId = 3
                        },
                        new Product()
                        {
                            Title = "SSD NVMe 1TB",
                            Description = "Vitesse élevée et fiabilité pour un stockage rapide",
                            Price = 179.99,
                            ImageUrl = "/images/p3.jpg",
                            createdAt = DateTime.Now.AddDays(-19),
                            CategoryId = 2,
                            SupplierId = 2
                        },
                        new Product()
                        {
                            Title = "Casque Gaming Surround 7.1",
                            Description = "Son immersif pour une expérience de jeu exceptionnelle.",
                            Price = 129.99,
                            ImageUrl = "/images/p3.jpg",
                            createdAt = DateTime.Now.AddDays(-1),
                            CategoryId = 3,
                            SupplierId = 1
                        },
                    });
                    context.SaveChanges();
                }
              
               
            }

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@eproducts.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@eproducts.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
