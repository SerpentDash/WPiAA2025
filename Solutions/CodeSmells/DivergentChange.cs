using System;

namespace CodeSmells
{
    public class UserAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationService
    {
        public bool Login(string username, string password)
        {
            Console.WriteLine("Authenticating user...");
            return "user" == username && "pass" == password;
        }

        public void Logout(string username)
        {
            Console.WriteLine($"{username} logged out.");
        }
    }

    public class UserReportGenerator
    {
        public void GenerateReport(UserAccount user)
        {
            Console.WriteLine($"Generating user report for {user.Username}");
        }
    }
}
