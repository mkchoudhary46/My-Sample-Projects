using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{

    public interface IFactory
    {
        void Drive(int miles);
    }

    public class Scooter : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive scooter");
        }
    }

    public class Bike : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive Bike");
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(string vehicle);
    }

    public class ConcreteVehicle : VehicleFactory
    {
        public override IFactory GetVehicle(string vehicle)
        {
            switch (vehicle)
            {
                case "scooter":
                    return new Scooter();
                default:
                    return new Bike();
            }
        }
    }
}
