using System;

namespace CodeSmells
{
    public class AdminPanel
    {
        private readonly UserManager _userManager = new UserManager();
        private readonly SystemConfigurator _configurator = new SystemConfigurator();
        private readonly LogRegistrar _logRegistrar = new LogRegistrar();
        private readonly SystemReportGenerator _reportGenerator = new SystemReportGenerator();

        public void ManageUsers()
        {
            _userManager.ManageUsers();
        }

        public void ConfigureSystem()
        {
            _configurator.Configure();
        }

        public void RegisterLog(string log)
        {
            _logRegistrar.RegisterLog(log);
        }

        public void GenerateSystemReport()
        {
            _reportGenerator.GenerateReport();
        }
    }

    public class UserManager
    {
        public void ManageUsers()
        {
            Console.WriteLine("Managing users.");
        }
    }

    public class SystemConfigurator
    {
        public void Configure()
        {
            Console.WriteLine("Configuring system.");
        }
    }

    public class LogRegistrar
    {
        public void RegisterLog(string log)
        {
            Console.WriteLine($"Log: {log}");
        }
    }

    public class SystemReportGenerator
    {
        public void GenerateReport()
        {
            Console.WriteLine("System report generated.");
        }
    }
}
