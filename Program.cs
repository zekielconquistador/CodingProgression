using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApp.SetupDemo
{
    internal class Program
    {
        static bool running = true;

        static Product[] products = new Product[]
        {
           new Product {Name = "Keyboard", Price = 29.99, Stock = 100 },
           new Product {Name = "Mouse", Price = 19.99, Stock = 100},
           new Product {Name = "Monitor", Price = 199.99, Stock = 50},
        };

        static void Main()
        {
            while (running)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("====================");
                    Console.WriteLine("1.Show Product");
                    Console.WriteLine("Q. Quit");
                    Console.Write("Enter choice: ");
                    string choice = Console.ReadLine();

                    if (string.IsNullOrEmpty(choice))
                    {
                        Console.WriteLine("Choice cannot be empty");
                        continue;
                    }
                    if (choice.ToUpper() == "Q")
                    {
                        running = false;
                        continue;
                    }



                    switch (choice)
                    {
                        case "1":
                            Products();
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void ShowProducts()
        {
            Console.WriteLine("=================");
            Console.WriteLine("    PRODUCTS");
            Console.WriteLine("=================");
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"Prod Num:{i + 0}. {products[i].Name} - Price: {products[i].Price} - Stocks: {products[i].Stock}");
            }
        }

        static void Products()
        {
            try
            {
                ShowProducts();
                Console.Write("Enter product number: ");
                int prodNum = int.Parse(Console.ReadLine());

                if (prodNum < 0 || prodNum >= products.Length)
                {
                    Console.WriteLine("Invalid product number");
                    return;
                }

                if (prodNum != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Add to cart");
                    Console.WriteLine("2. Purchase");
                    Console.WriteLine("B. Back");
                    Console.Write("Enter choice: ");
                    string input = Console.ReadLine().ToUpper();

                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Added to cart");
                            break;
                        case "2":
                            Console.WriteLine("Purchased");
                            break;
                        case "B":
                            return;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
