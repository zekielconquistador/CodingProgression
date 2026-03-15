using System;
using System.Diagnostics;

class Program
{
    static double Calculation(params double[] prices)
    {
        double total = 0;
        foreach (double price in prices)
        {
            total += price;
        }
        return total;
    }

    static void Main()
    {
        bool running = true;

        while (running)
        {
            try
            {
                Console.Write("Enter number of items: ");
                int size = Convert.ToInt32(Console.ReadLine());

                if (size >= 20)
                    throw new Exception("Too many items. Please enter 20 or fewer items.");
                if (size <= 0)
                    throw new Exception("Number of items must be greater than zero.");

                double[] prices = new double[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write($"Enter price for item {i + 1}: ");
                    prices[i] = Convert.ToDouble(Console.ReadLine());
                }

                double result = Calculation(prices);
                Console.WriteLine($"Total: {result}");
                string discountMessage = GetDiscount(result);
                Console.WriteLine(discountMessage);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Debug.WriteLine($"FormatException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            Console.Write("Do you want to calculate again? (y/n): ");
            string again = Console.ReadLine();

            switch (again.ToLower())
            {
                case "y":
                    continue;
                case "n":
                    Console.WriteLine("Exiting the program...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting the program...");
                    running = false;
                    break;
            }
        }
        Console.ReadKey();
    }

    static string GetDiscount(double totalAmount)
    {
        return totalAmount >= 100
            ? "You get a 10% discount!"
            : "No discount available.";
    }
}