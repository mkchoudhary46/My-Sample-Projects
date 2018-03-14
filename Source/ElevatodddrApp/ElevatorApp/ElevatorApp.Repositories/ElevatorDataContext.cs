using System.Collections.Generic;
using ElevatorApp.DAO;

namespace ElevatorApp.Repositories
{
    public class ElevatorDataContext :IElevatorDataContext
    {
        public IEnumerable<Floor> Floors
        {
            get
            {
                return new List<Floor>
                {
                    new Floor() {Id = 1, IsActive = true},
                    new Floor() {Id = 2, IsActive = true},
                    new Floor() {Id = 3, IsActive = true},
                    new Floor() {Id = 4, IsActive = true},
                    new Floor() {Id = 5, IsActive = true}
                };
            }
            
        }
    }
}
