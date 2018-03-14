using System;
using RocketLauncherApp.Models;
using RocketLauncherApp.Services;

namespace RocketLauncherApp
{
    public class Application : IApplication
    {
        private readonly IRocketLauncherAppService _rocketLauncherAppService;

        public Application(IRocketLauncherAppService rocketLauncherAppService)
        {
            _rocketLauncherAppService = rocketLauncherAppService;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select Any Option:");
                Console.WriteLine("1. Create Rocket.");
                var input = Console.ReadKey();
                int inputId;
                int.TryParse(input.KeyChar.ToString(), out inputId);
                switch (inputId)
                {
                    case 1:
                        Console.WriteLine("Enter Rocket Name:\n");
                        var name = Console.ReadLine();
                        _rocketLauncherAppService.CreateRocket(new RocketViewModel(name));
                        break;
                    default:
                        Console.WriteLine("Output not available");
                        break;

                }
                _rocketLauncherAppService.CreateRocket(new RocketViewModel());
                Console.WriteLine("Press Any Key !!!");
                Console.ReadKey();
            }
        }
    }
}
