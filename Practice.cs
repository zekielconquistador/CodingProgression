using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Xml.Schema;
class Program
{
    static string[] user = new string[100];
    static bool running = true;
    static double[] hhours = new double[100];
    static double[] mminutes = new double[100];
    static double[] sseconds = new double[100];
    static void Main(string[] args)
    {
        while (running)
        {
            Register();
        }
    }
    static void Register()
    {
       try
        {
            Console.Clear();
            Console.WriteLine("Welcome to Soul Society");
            Console.WriteLine();
            Console.Write("Enter name: ");
            user[0] = Console.ReadLine();

            if (user[0] != null)
            {
                Console.WriteLine("Account created successfully!");
            }
            else
            {
                Console.WriteLine("Failed to create account. Please try again.");
            }

            Menu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ViewAccounts()
    {
        for (int i = 0; i < user.Length; i++)
        {  
            if (user[i] != null)
            {
                Console.WriteLine($"Names: {user[i]}  History: {hhours[i]}0:{mminutes[i]}0:{sseconds[i]}0");
            }
        }
    }      

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("============================");
        Console.WriteLine("============================");

        Console.Write("Enter hours: ");
        double hours = int.Parse(Console.ReadLine());

        Console.Write("Enter minutes: ");
        double minutes = int.Parse(Console.ReadLine());

        Console.Write("Enter seconds: ");
        double seconds = int.Parse(Console.ReadLine());

        hhours[0] = hours;
        mminutes[0] = minutes;
        sseconds[0] = seconds;

        double totalSeconds = (hours * 3600) + (minutes * 60) + seconds;
        while (totalSeconds > 0)
        {
            double h = totalSeconds / 3600;
            double m = (totalSeconds % 3600) / 60;
            double s = totalSeconds % 60;

            Console.Clear();
            Console.WriteLine($"Time remaining: {totalSeconds} seconds");
            Thread.Sleep(1000);
            totalSeconds--;
        }
        Console.WriteLine("Times up!");

        Console.WriteLine("Enter M to back to registration");
        Console.WriteLine("Enter D to show dashboard");
        Console.Write("Do you want to fill up again (y/n)? ");
        string choice = Console.ReadLine();

        switch (choice.ToLower())
        {
            case "y":
                Menu();
                break;
            case "n":
                Console.WriteLine("Exiting the program. Goodbye!");
                running = false;
                break;
            case "m":
                return;
            case "d":
                ViewAccounts();
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                Menu();
                break;
            default:
                Console.WriteLine("Invalid choice. Exiting the program.");
                running = false;
                break;
        }
    }
}