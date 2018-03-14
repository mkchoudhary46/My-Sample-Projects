using System.Collections.Generic;
using ElevatorApp.DAO;

namespace ElevatorApp.Repositories
{
    public interface IElevatorRepository
    {
        IEnumerable<Floor> GetFloors();
        Floor GetFloorById(int id);
    }
}
