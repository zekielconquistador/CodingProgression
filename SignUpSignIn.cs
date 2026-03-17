using System;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Transactions;

class Program
{
    const int MAX_USERS = 8000000;
    const int MAX_PASSWORD_LENGTH = 100;

    static string[,] users = new string[MAX_USERS, 3];
    static int userCount = 0;

    static Random rnd = new Random();

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            int choice = ShowMenu();

            switch (choice)
            {
                case 1:
                    SignUp();
                    break;
                case 2:
                    SignIn();
                    break;
                case 3:
                    Console.WriteLine("Exiting...");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }
    }

    static int ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("THIS PROGRAM IS WRITTEN BY FRANK AI");
        Console.WriteLine("1. SIGN UP");
        Console.WriteLine("2. LOG IN");
        Console.WriteLine("3. EXIT");
        Console.Write("Enter choice: ");

        try
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return -1;
        }
        catch (OverflowException)
        {
            Console.WriteLine("Input number is too large. Please enter a valid number.");
            return -1;
        }
    }

    static void SignUp()
    {
        Console.WriteLine();
        Console.WriteLine("CREATE AN ACCOUNT");
        Console.WriteLine();
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        Console.Clear();

        string[] errors = Validate(username, email, password);

        bool hasErrors = false;

        foreach (string error in errors)
        {
            if (error != null)
            {
                Console.WriteLine("Error: " + error);
                hasErrors = true;
            }
        }

        if (!hasErrors)
        {
            users[userCount, 0] = username;
            users[userCount, 1] = email;
            users[userCount, 2] = password;
            userCount++;
            
            int otp = rnd.Next(100000, 999999);

            Console.WriteLine($"Verification OTP: {otp} check your emeail");

            double strength = Math.Round(Math.Sqrt(password.Length) * 33.3, 1);
            strength = Math.Min(strength, 100);
            Console.WriteLine($"Password Strenth: {strength}%");
        }
    }

    static void SignIn()
    {
        Console.WriteLine();
        Console.WriteLine("LOG YOUR ACCOUNT");
        Console.WriteLine();
        Console.Write("Enter Username:");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        Console.Clear();

        int idx = FindUser(username);

        bool found = idx != -1;
        bool passOk = found && users[idx, 2] == password;

        string status = passOk ? "SUCCESS" : "FAILED";

        if (passOk)
        {
            Console.WriteLine($"Login {status}! Welcome back {Capitalize(username)}");
            ShowOverview(idx);
        }
        else
        {
            Console.WriteLine($"Login {status}! Please check your credentials and try again.");
        }
    }

    static void ShowOverview(int idx)
    {
        Header($"OVERVIEW - {Capitalize(users[idx, 0])}");

        int daysActive = rnd.Next(1, 365);
        double avgSession = Math.Round(rnd.NextDouble() * 60, 2);
        double score = Math.Pow(daysActive, 0.5) * 10;
        score = Math.Ceiling(score);

        int displayScore = (int)score;

        Console.WriteLine($" EMAIL         : {users[idx, 1]}");
        Console.WriteLine($" DAYS ACTIVE   : {daysActive, 5}");
        Console.WriteLine($" AVG SESSION   : {avgSession, 5}");
        Console.WriteLine($" TRUST SCORE   : {displayScore, 5}");

        Console.WriteLine("\n  Activity (last 4 weeks — ■ active  □ inactive):");
        for (int week = 1; week <= 4; week++)
        {
            Console.Write($" Week {week}: ");
            for (int day = 0; day <= 7; day++)
            {
                Console.Write(rnd.Next(0, 2) == 1 ? "■ " : "□ ");
            }
            Console.WriteLine();
        }

        string[] tips =
        {
            "Enable two-factor authentication for added security.",
            "Review your active sessions and",
            "Update your recovery email",
            "Check recent login history"
        };

        Console.WriteLine("Security Tips");
        for (int i = 0; i < tips.Length; i++)
        {
            Console.WriteLine($" {i + 1}. {tips[i]}");
        }

        Console.WriteLine("Press any key to return");
        Console.ReadKey(true);

        Console.Clear();
    }

    static string[] Validate(string username, string email, string password)
    {
        string[] errors = new string[4];
        int ei = 0;

        if (username.Length < 3)
            errors[ei++] = "Username must be at least 4 characters long";

        if (FindUser(username) != -1)
            errors[ei++] = "Username already exists"; 

        if (FindUserByEmail(email) != -1)
            errors[ei++] = "Email already exists";

        if (password.Length < 8)
            errors[ei++] = "Password must be at least 8 characters long";

        if (!email.Contains("@") || !email.Contains("."))
            errors[ei++] = "Invalid email format";

        return errors;
    }

    static bool Validate(string username, string password)
    {
        return username.Length >= 8 && password.Length >= 8;
    }

    static int FindUser(string username)
    {
        for (int i = 0; i < userCount; i++)
        {
            if (users[i, 0] == username) 
                return i;
        }
        return -1;
    }

    static int FindUserByEmail(string email)
    {
        for (int i = 0; i < userCount; i++)
        {
            if (users[i, 1] == email) 
                return i;
        }
        return -1;
    }
    static string Capitalize(string s) =>
        s.Length == 0 ? s : s.Substring(0, 1).ToUpper() + s.Substring(1);

    static void Header(string title) =>
         Console.WriteLine($"\n── {title} {'─'.ToString().PadRight(22 - title.Length, '─')}");
}
