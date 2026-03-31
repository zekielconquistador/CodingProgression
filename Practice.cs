using System;
using System.Threading;

class Prorgam
{
    static void Main()
    {
        int rows = 5;
        int cols = 5;
        int count = 25;

        string[,] seats = new string[rows, cols];

        while (true)
        {
            Console.Clear();

            Console.WriteLine("=====Seating=====");
            for (int i = 0;i < rows; i++)
            {
                for (int j = 0;j < cols; j++)
                {
                    char rowLetter = (char)('A' + i);
                    int colNumber = j + 1;

                    Console.Write($"{rowLetter}{colNumber}{seats[i,j]} ");
                }
                Console.WriteLine();
            }

            try
            {
                Console.Write("Enter row: ");
                string input = Console.ReadLine().ToUpper();

                char rowChar = input[0];
                int col = Convert.ToInt32(input[1].ToString());

                int row = rowChar - 'A';
                col = col - 1;

                count--;

                if (seats[row, col] == "x")
                {
                    Console.WriteLine("This seat already booked!");
                }
                else
                {
                    seats[row, col] = "x";
                    Console.WriteLine("Seat is booked!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine($"Seat count {count}");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
    }
}