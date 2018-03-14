using System;
using System.Linq;
using System.Reflection;
using Autofac;
using ElevatorApp.Mappers;
using ElevatorApp.Repositories;
using ElevatorApp.Services;

namespace ElevatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacRegistration.ConfigureContainer();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
