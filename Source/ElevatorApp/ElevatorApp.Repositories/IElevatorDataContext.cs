using System.Collections.Generic;
using ElevatorApp.DAO;

namespace ElevatorApp.Repositories
{
    public interface IElevatorDataContext
    {
        IEnumerable<Floor> Floors { get;}
    }
}
