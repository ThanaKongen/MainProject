using System;
using System.Linq;
using ConsoleApp1.Models;
using ConsoleApp1.Data;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            using testingContext Context = new testingContext();

            //Delete
            var test = Context.Products
                .Where(p => p.Name == "Test").FirstOrDefault();

            if (test is Product)
            {
                Context.Remove(test);
            }
            Context.SaveChanges();
            
            //---
            ////Update
            //var test = Context.Products
            //    .Where(p => p.Name == "Test").FirstOrDefault();
            //if (test is Product)
            //{
            //    test.Price = 7.99m;
            //}
            //Context.SaveChanges();
            ////-----

            //Select
            var products = Context.Products
                .Where(p => p.Price >= 6.5m)
                .OrderBy(p => p.Name);

            foreach (Product product in products)
            {
                Console.WriteLine($"Id:{product.Id}");
                Console.WriteLine($"Name:{product.Name}");
                Console.WriteLine($"Price:{product.Price}");
                Console.WriteLine(new string('-', 20));
            }
            //-----

            //Post
            TestCustomer customer = new TestCustomer()
            {
                FirstName = "Test",
                LastName = "h",
                CVR = ""
            };
            Context.Add(customer);

            Product Ball = new Product()
            {
                Name = "ball",
                Price = 5.4M
            };
            Context.Add(Ball);

            PrivateCustomer privateCustomer = new PrivateCustomer()
            {
                FirstName = "PrivateTest",
                LastName = "Z",
                CPR = ""
            };
            Context.SaveChanges();

            //----
        }
    }
}
