using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace RocketLauncherApp.Data.Sql
{
    class Program
    {
        private const string DbName = "DefaultConnection";

        private static int Main(string[] args)
        {
            Console.WriteLine("Deployment/upgrade beginning for database '{0}'...", DbName);

            var connectionString =
                args.FirstOrDefault()
                ?? GetConnectionString()
                ?? "Data Source=.;Initial Catalog=RocketLauncherApp;Integrated Security=True";

            var result = PerformUpgrade(connectionString);

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                if (Debugger.IsAttached) Debugger.Break();
                return -1;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }

        private static string GetConnectionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[DbName].ConnectionString;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DatabaseUpgradeResult PerformUpgrade(string connectionString)
        {
            Console.WriteLine("Connection: '{0}'.", connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithExecutionTimeout(TimeSpan.FromMinutes(6))
                .LogToConsole()
                .Build();

            return upgrader.PerformUpgrade();
        }
    }
}
