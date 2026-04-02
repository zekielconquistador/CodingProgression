using System;
using System.Data.SqlTypes;
using System.Net;
using System.Runtime.ExceptionServices;

class Practice
{
    static int rows = 5;
    static int cols = 5;
    static string[,] seats = new string[rows, cols];
    static bool running = true;
    static string input = "";
    static void Main()
    {
        int count = 25;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                seats[i, j] = "O"; // O = available
            }
        }

        while (running)
        {
            Console.Clear();

            Seats();

            try
            {
                Console.WriteLine("O = Available | X = Taken");

                Console.Write("Enter seats (e.g A1): ");
                input = Console.ReadLine().ToUpper();

                char rowChar = input[0];
                int col = Convert.ToInt32(input[1].ToString());

                int row = rowChar - 'A';
                col = col - 1;

                if (row < 0 || row >= rows || col < 0 || col >= cols)
                {
                    Console.WriteLine("Invalid seat");
                }
                else if (seats[row, col] == "X")
                {
                    Console.WriteLine("Seat already booked");
                }
                else
                {
                    seats[row, col] = "X";
                    count--;
                    Console.WriteLine("Seat booked!");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine($"Seat count: {count}");
            Console.WriteLine($"Seat: {input}");

            Again();
        }
    }

    static void Seats()
    {
        Console.WriteLine("SEATING");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0;  j < cols; j++)
            {
                char rowLetter = (char)('A' + i);
                int colNum = j + 1;

                Console.Write($"{rowLetter}{colNum,2}({seats[i, j]})");
            }
            Console.WriteLine();
        }
    }
    static void Again()
    {   
        Console.WriteLine("M = menu");
        Console.WriteLine("E = exit");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine().ToUpper();

        switch (choice)
        {
            case "M":
                return;
            case "E":
                Console.WriteLine("Exiting.....");
                running = false;
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
}