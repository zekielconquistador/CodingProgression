using System;
using System.IO.Pipes;
using System.Net.Http.Headers;

class SignUpSignIn
{
    const int MAX_USERS = 80000000;
    static string[] users = new string[MAX_USERS];
    static string[] passwords = new string[MAX_USERS];
    static string[] usernames = new string[MAX_USERS];
    static int userCount = 0;
    static new Random rand = new Random();
    static void Main(string[] args)
    {
        Console.WriteLine("WECLOME TO MY SYSTEM POWERED BY WINGFORGE");
        Console.WriteLine("1. SIGN IN");
        Console.WriteLine("2. SIGN UP");
        Console.WriteLine("3. Exit");
        Console.Write("Enter choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        bool running = true;

        while (running)
        {
            switch (choice)
            {
                case 1:
                    SignIn();
                    break;
                case 2:
                    SignUp();
                    break;
                case 3:
                    Console.WriteLine("Exiting the program......");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    static void SignUp()
    {
        try
        {
            if (users.Length >= MAX_USERS)
            {
                Console.WriteLine("User limit reached. Cannot register more users.");
                return;
            }

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            if (username == " ")
                throw new Exception("Username cannot be empty.");

            if (username.Length > 20)
                throw new Exception("Username cannot exceed 20 characters.");

            if (UserExist(username))
                throw new Exception("Username already exists. Please choose a different username.");

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (password.Length < 8)
                throw new Exception("Password must be at least 8 characters long.");

            usernames[userCount] = username;
            passwords[userCount] = password;
            userCount++;

            Console.WriteLine("Account created successfully!");
            Console.WriteLine("Welcome " + username);

            int otp = GenerateOTP();
            Console.WriteLine("Your one-time verification code " + otp);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error " + ex.Message);
        }
    }

    static void SignIn()
    {
        Console.Clear();
        Console.WriteLine("SIGN IN");
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
    }

    static bool UserExist(string username)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == username)
                return true;
        }
        return false;
    }
    static int GenerateOTP()
    {
        return rand.Next(100000, 999999);
    }
}