using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Lambda_expression
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public string CompanyName { get; set; }

        public override string ToString()
        {
            return $"Id={Id} Name={Name} Price={Price} Company Name={CompanyName}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product{Id=1,Name="Mouse",Price=799,CompanyName="Dell"},
                new Product{Id=2,Name="Mouse",Price=699,CompanyName="Lenovo"},
                new Product{Id=3,Name="Laptop",Price=34799,CompanyName="Dell"},
                new Product{Id=4,Name="Laptop",Price=45799,CompanyName="Sony"},
                new Product{Id=5,Name="Laptop",Price=38799,CompanyName="Lenovo"},
                new Product{Id=6,Name="Keyboard",Price=599,CompanyName="Dell"},
                new Product{Id=7,Name="Keyboard",Price=999,CompanyName="Microsoft"},
                new Product{Id=8,Name="RAM 4GB",Price=2799,CompanyName="Corsair"},
                new Product{Id=9,Name="Speaker",Price=5799,CompanyName="Sony"},
                new Product{Id=10,Name="USB Mouse",Price=1299,CompanyName="Microsoft"},
            };

            //Using LINQ query
            Console.WriteLine("Using LINQ query");
            Console.WriteLine("-----------------------------------------------------------");
            //Display all products using LINQ query

            var res1 = from p in products
                       select p;
            
            foreach (var item in res1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display products whose price is greater than 1500

            var res2 = from p in products
                       where p.Price > 1500
                       select p;
            foreach (var item in res2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display products whose price is in between 10000 to 40000
            var res3= from p in products
                      where p.Price<40000 & p.Price>10000
                      select p;
            foreach (var item in res3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------------------------------");

            //Display products of Dell company
            var res4 = from p in products
                       where p.CompanyName == "Dell"
                       select p;
            foreach (var item in res4)
            {
                    Console.WriteLine(item);
            }



            Console.WriteLine("-----------------------------------------------------------");

            //Display all company laptops
            var res5 = from p in products
                       where p.Name == "Laptop"
                       select p;
            foreach (var item in res5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");
            
            //Display products whose company name start with ‘M’
            var res6= from p in products
                      where p.CompanyName.StartsWith("M")
                      select p;
            foreach (var item in res6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display all company mouse whose price is less than 1000
            var res7 = from p in products
                       where p.Price < 1000 & p.Name =="Mouse"
                       select p;
            foreach (var item in res7)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display all products descending order by their price
            var res8= from p in products
                      orderby p.Price descending
                      select p;
            foreach (var item in res8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display all products accessing order by their company name
            var res9= from p in products
                      orderby p.CompanyName ascending
                      select p;
            foreach (var item in res9)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display all keyboards accessing order by their price
            var res10= from p in products
                       where p.Name== "Keyboard"
                       orderby p.Price ascending
                       select p;
            foreach (var item in res10)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("-----------------------------------------------------------"); 
            Console.WriteLine("-----------------------------------------------------------");


            //Using Lambda Expressions
            Console.WriteLine("Using Lambda Expressions");
            Console.WriteLine("-----------------------------------------------------------");
            //Display all products descending order by their price

            var lres = products.OrderByDescending(p => p.Price).ToList();
            
            foreach (var item in lres)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display product whose Id is 5
            var lres2=products.Where(p=>p.Id==5).FirstOrDefault();
            Console.WriteLine(lres2);
           
            Console.WriteLine("-----------------------------------------------------------");

            //Display all products whose price less than 5000
            var lres3=products.Where(p=>p.Price<5000).ToList();
            foreach (var item in lres3)
            {
                Console.WriteLine(item); 
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display 3 products which have maximum price
            var lres4=products.OrderByDescending(p=>p.Price).Take(3);
            foreach (var item in lres4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------");

            //Display 5 products which have minimum price
            var lres5 = products.OrderBy(p => p.Price).Take(5);
            foreach (var item in lres5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------"); 
            Console.WriteLine("-----------------------------------------------------------");

        }
    }
}
