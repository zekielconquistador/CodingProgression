using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;

class Pratice
{
    static Random rnd = new Random();

    static void Main()
    {
        MainMenu();
    }
    static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("GUESSING GAME");
            Console.WriteLine("1. Easy (1 to 20)");
            Console.WriteLine("2. Medium (1 to 50)");
            Console.WriteLine("3 Hard (1 to 100)");
            Console.WriteLine();
            Console.Write("Enter difficulty: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Easy();
                    break;
                case 2:
                    Medium();
                    break;
                case 3:
                    Hard();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    static void Easy()
    {
        int count = 0;
        const int MIN = 1;
        const int MAX = 20;

        int secretNum = rnd.Next(MIN, MAX + 1);
        bool running = true;
        Console.WriteLine("DIFFICULTY: EASY");

        while (running)
        {
           try
            {
                Console.WriteLine();
                Console.Write("Enter number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (num > MAX || num < MIN)
                {
                    Console.WriteLine($"Guess must be between {MIN} to {MAX}");
                }
                else if (num > secretNum)
                {
                    Console.WriteLine("Too High. Try again");
                }
                else if (num < secretNum)
                {
                    Console.WriteLine("Too Low. Try again");
                }
                
                else
                {
                    Console.Clear();
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"The number is {secretNum}");
                    Console.WriteLine($"Number of guesses: {count + 1}");

                    Console.WriteLine("Enter m to back to menu");
                    Console.Write("Do you want to continue?(y/n): ");
                    string again = Console.ReadLine().ToLower();

                    switch (again)
                    {
                        case "m":
                            Console.Clear();
                            return;
                        case "y":
                            secretNum = rnd.Next(MIN, MAX + 1);
                            count = 0;
                            Console.Clear();
                            break;
                        case "n":
                            Console.WriteLine("BYE");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            running = false;
                            break;
                    }
                }
                count++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        
    }

    static void Medium()
    {
        int count = 0;
        const int MIN = 1;
        const int MAX = 50;

        int secretNum = rnd.Next(MIN, MAX + 1);
        bool running = true;
        Console.WriteLine("DIFFICULTY: MEDIUM");

        while (running)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Enter number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (num > MAX || num < MIN)
                {
                    Console.WriteLine($"Guess must be between {MIN} to {MAX}");
                }
                else if (num > secretNum)
                {
                    Console.WriteLine("Too High. Try again");
                }
                else if (num < secretNum)
                {
                    Console.WriteLine("Too Low. Try again");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"The number is {secretNum}");
                    Console.WriteLine($"Number of guesses: {count + 1}");

                    Console.WriteLine("Enter m to back to menu");
                    Console.Write("Do you want to continue?(y/n): ");
                    string again = Console.ReadLine().ToLower();

                    switch (again)
                    {
                        case "m":
                            Console.Clear();
                            return;
                        case "y":
                            secretNum = rnd.Next(MIN, MAX + 1);
                            count = 0;
                            Console.Clear();
                            break;
                        case "n":
                            Console.WriteLine("BYE");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            running = false;
                            break;
                    }
                }
                count++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }

    static void Hard()
    {
        int count = 1;
        const int MIN = 1;
        const int MAX = 100;

        int secretNum = rnd.Next(MIN, MAX + 1);
        bool running = true;
        Console.WriteLine("DIFFICULTY: HARD");

        while (running)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Enter number: ");
                int num = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (num > MAX || num < MIN)
                {
                    Console.WriteLine($"Guess must be between {MIN} to {MAX}");
                }
                else if (num > secretNum)
                {
                    Console.WriteLine("Too High. Try again");
                }
                else if (num < secretNum)
                {
                    Console.WriteLine("Too Low. Try again");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Correct!");
                    Console.WriteLine($"The number is {secretNum}");
                    Console.WriteLine($"Number of guesses: {count + 1}");

                    Console.WriteLine("Enter m to back to menu");
                    Console.Write("Do you want to continue?(y/n): ");
                    string again = Console.ReadLine().ToLower();

                    switch (again)
                    {
                        case "m":
                            Console.Clear();
                            return;
                        case "y":
                            secretNum = rnd.Next(MIN, MAX + 1);
                            count = 0;
                            Console.Clear();
                            break;
                        case "n":
                            Console.WriteLine("BYE");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            running = false;
                            break;
                    }
                }
                count++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}