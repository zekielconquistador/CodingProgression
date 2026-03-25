using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Practice
{
    static void Main()
    {
        const int MAX_SUBJECTS = 8;
        
        string[] subjects = new string[MAX_SUBJECTS];
        double[] grades = new double[MAX_SUBJECTS];

        double total = 0;
        int count = 0;

        for (int i = 0; i < subjects.Length; i++)
        {
            bool running = true;
            bool found = false;

            while (running)
            {
                Console.Write($"Enter subjects {i + 1}: ");

                try
                {
                    string subjectInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(subjectInput))
                    {
                        Console.WriteLine("Subject cannot be empty. Please try again.");
                        continue;
                    }

                    foreach (string subject in subjects)
                    {
                        if (subjectInput == subject)
                        {
                            Console.WriteLine("Subject already exists");
                            found = true;
                            break;
                        }
                    }
                    subjects[i] = subjectInput;


                    Console.Write($"Enter grade for {subjects[i]}: ");
                    grades[i] = double.Parse(Console.ReadLine());

                    if (grades[i] < 0 || grades[i] > 100)
                    {
                        Console.WriteLine("Grade must be between 0 and 100. Please try again.");
                        continue;
                    }
                    else
                    {
                        total += grades[i];
                        count++;
                        running = false;
                    }

                   
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid grade.");
                    continue;
                }
            }
        }

        double average = total / grades[0];

        
        for (int i = 0; i < subjects.Length &&  i < grades.Length; i++)
        {
            Console.WriteLine($"Subject: {subjects[i].ToUpper()}, Grade: {grades[i]}");
        }

        Console.WriteLine($"Average: {Math.Round(average, 2)}");

    }
}