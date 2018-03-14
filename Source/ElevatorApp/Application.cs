using System;
using System.Collections.Generic;
using System.Linq;
using ElevatorApp.Models;
using ElevatorApp.Services;

namespace ElevatorApp
{
    public class Application : IApplication
    {
        private readonly IElevatorService _elevatorService;

        public Application(IElevatorService elevatorService)
        {
            _elevatorService = elevatorService;
        }

        public void MoveLift(int floor)
        {
            _elevatorService.MoveLift(floor);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                var currentFloor = _elevatorService.GetCurrentFloor();
                var floors = _elevatorService.GetAllFloors();
                Console.WriteLine("Current Floor {0}", currentFloor.Id);
                Console.WriteLine(string.Join(",", floors.Select(x => x.Id)));
                Console.WriteLine("Enter Floor Id:");
                var userInput = Console.ReadKey();
                Console.WriteLine();
                ProcessUserInput(userInput, floors);
                Console.WriteLine("Press Any Key !!!");
                Console.ReadKey();
            }
        }

        private void ProcessUserInput(ConsoleKeyInfo userInput, IEnumerable<FloorModel> allFloors)
        {
            int floorId;
            int.TryParse(userInput.KeyChar.ToString(), out floorId);
            if (allFloors.Any(p => p.Id == floorId))
            {
                var response = _elevatorService.MoveLift(floorId);
                Console.WriteLine(response + ":" + Elevator.CurrentFloor);
            }
            else
            {
                Console.WriteLine("Please enter valid floor!!");
            }
        }
    }
}
