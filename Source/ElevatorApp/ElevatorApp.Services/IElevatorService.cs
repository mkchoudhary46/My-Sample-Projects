using System.Collections.Generic;
using ElevatorApp.Common.Enumerations;
using ElevatorApp.Models;

namespace ElevatorApp.Services
{
    public interface IElevatorService
    {
        ElevatorMovementStatus MoveLift(int targetFloor);
        IEnumerable<FloorModel> GetAllFloors();
        FloorModel GetCurrentFloor();
        void SetCurrentFloor(int id);
    }
}
