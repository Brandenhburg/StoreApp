using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Repository;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data
{
    public class StoreSeeder
    {
        public static void SeedData(StoreDbContext context)
        {
            if (context.Categories.Count() == 0)
            {
                context.Categories.AddRange(categories); 
                
            }
            if (context.Authors.Count() == 0)
            {
                context.Authors.AddRange(authors);
            }

            if (context.Products.Count() == 0)
            {
                context.Products.AddRange(products);
            }

            context.SaveChanges();
        }


        private static readonly Category[] categories = 
        {
            new Category { Name = "Python" },
            new Category { Name = "Microsoft & .Net" },
            new Category { Name = "Databases" },
            new Category { Name = "Security" },
            new Category { Name = "Web Development" }
         };

        private static readonly Author[] authors =
        {
            new Author { Name = "Adam Freeman"},
            new Author { Name = "Andrew Troelsen"},
            new Author { Name = "Panos Matsinopoulos"},
            new Author { Name = "Morey J. Haber"},
            new Author { Name = "Elizabeth Noble"},
            new Author { Name = "Krogh, Jesper Wisborg"},
            new Author { Name = "David Ashley"},
            new Author { Name = "Carter, Peter A."},
            new Author { Name = "Pajankar, Ashwin"},
        };


        private static readonly Product[] products =
        {
            new Product { Name = "Pro C# 8 with .NET Core 3", Price = 49.99M,
                Description = "This essential classic provides a comprehensive foundation in the C# programming language and the frameworks it lives in",
                Categories = categories[1],
                Authors = authors[1]
            },

            new Product { Name = "Pro Entity Framework Core 2 for ASP.NET Core MVC", Price = 49.99M,
                Description = "Model, map, and access data effectively with Entity Framework Core 2, the latest evolution of Microsoft’s object-relational mapping framework.",
                Categories = categories[2],
                Authors = authors[0],
            },

            new Product { Name = "Pro ASP.NET Core 3", Price = 49.99M,
                Description = "Now in its 8th edition, Pro ASP.NET Core has been thoroughly updated for ASP.NET Core 3 and online for ASP.NET Core 5 and .NET 5.0.",
                Categories = categories[1],
                Authors = authors[0]
            },

            new Product {Name = "Practical Bootstrap", Price = 29.99M,
                Description = "Learn to use one of the most popular CSS frameworks and build mobile-friendly web pages. Used for numerous websites and applications, Bootstrap is a key tool for modern web development.",
                Categories = categories[4],
                Authors = authors[2]
            },

            new Product {Name = "Privileged Attack Vectors", Price = 29.99M,
                Description = "See how privileges, insecure passwords, administrative rights, and remote access can be combined as an attack vector to breach any organization",
                Categories = categories[3],
                Authors = authors[3]
            },

            new Product {Name = "Identity Attack Vectors", Price = 22.99M,
                Description = "Discover how poor identity and privilege management can be leveraged to compromise accounts and credentials within an organization.",
                Categories = categories[3],
                Authors = authors[3]
            },

            new Product {Name = "Asset Attack Vectors", Price = 19.99M,
                Description = "See how privileges, passwords, vulnerabilities, and exploits can be combined as an attack vector and breach any organization.",
                Categories = categories[3],
                Authors = authors[3]
            },

            new Product { Name = "Pro T-SQL2019", Price=26.99M,
                Description = "Design and write simple and efficient T-SQL code in SQL Server 2019 and beyond. Writing T-SQL that pulls back correct results can be challenging.",
                Categories = categories[2],
                Authors = authors[4]
            },

            new Product { Name = "MySQL 8 Query Performance Tuning", Price=26.99M,
                Description = "Identify, analyze, and improve poorly performing queries that damage user experience and lead to lost revenue for your business.",
                Categories = categories[2],
                Authors = authors[5]
                },

            new Product { Name = "Applied Machine Learning for Health and Fitness", Price = 29.99M,
                Description ="Explore the world of using machine learning methods with deep computer vision, sensors and data in sports, health and fitness and other industries.",
                Categories = categories[0],
                Authors = authors[6]
            },

            new Product { Name = "Pro SQL Server 2019 Administration", Price = 29.99M,
                Description = "Use this comprehensive guide for the SQL Server DBA, covering all that practicing database administrators need to know to get their daily work done.",
                Categories = categories[2],
                Authors = authors[7]
            },

            new Product { Name = "Practical Python Data Visualization", Price = 26.99M,
                Description = "Quickly start programming with Python 3 for data visualization with this step-by-step, detailed guide. This book’s programming-friendly approach using libraries such as leather, NumPy, Matplotlib, and Pandas.",
                Categories = categories[0],
                Authors = authors[8]
            },

            new Product { Name = "Pro Angular 9", Price = 39.99M,
                Description = "Welcome to this one-stop-shop for learning Angular. Pro Angular is the most concise and comprehensive guide available, giving you the knowledge you need to take full advantage of this popular framework for building your own dynamic JavaScript applications.",
                Categories = categories[4],
                Authors = authors[0]
            }     
        };

    }
}
