using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ElevatorApp.Common.Enumerations;
using ElevatorApp.DAO;
using ElevatorApp.Models;
using ElevatorApp.Repositories;

namespace ElevatorApp.Services
{
    public class ElevatorService :IElevatorService
    {
        private readonly IElevatorRepository _elevatorRepository;

        public ElevatorService(IElevatorRepository elevatorRepository)
        {
            _elevatorRepository = elevatorRepository;
            Elevator.CurrentFloor = _elevatorRepository.GetFloors().Select(x => x.Id).FirstOrDefault();
        }

        public ElevatorMovementStatus MoveLift(int targetFloor)
        {
            if (Elevator.CurrentFloor == targetFloor)
            {
                return ElevatorMovementStatus.ElevatorOnSameFloor;
            }
            SetCurrentFloor(targetFloor);
            return ElevatorMovementStatus.ElevatorMoved;
        }

        public IEnumerable<FloorModel> GetAllFloors()
        {
            var data = _elevatorRepository.GetFloors();
            return Mapper.Map<IEnumerable<FloorModel>>(data);
        }

        public FloorModel GetCurrentFloor()
        {
            var data = _elevatorRepository.GetFloorById(Elevator.CurrentFloor);
            return  Mapper.Map<FloorModel>(data);
        }

        public void SetCurrentFloor(int id)
        {
            Elevator.CurrentFloor = id;
        }
    }
}
