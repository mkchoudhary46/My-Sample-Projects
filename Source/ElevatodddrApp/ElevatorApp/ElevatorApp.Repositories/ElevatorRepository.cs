using System.Collections.Generic;
using System.Linq;
using ElevatorApp.DAO;

namespace ElevatorApp.Repositories
{
    public class ElevatorRepository : IElevatorRepository
    {
        private readonly IElevatorDataContext _dataContext;

        public ElevatorRepository(IElevatorDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Floor> GetFloors()
        {
            return _dataContext.Floors;
        }

        public Floor GetFloorById(int id)
        {
            return GetFloors().FirstOrDefault(x => x.Id == id);
        }
    }
}
