using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creator[] creators = new Creator[2];
            //creators[0]= new ConcreteCreatorA();
            //creators[1]= new ConcreteCreatorB();
            //foreach (var creator in creators)
            //{
            //    var product = creator.FactoryMethod();
            //    Console.WriteLine(product.GetType().Name);
            //}

            var factory = new ConcreteVehicle();
            var fac= factory.GetVehicle("scooter");
            fac.Drive(10);
            Console.ReadKey();
        }
    }

    public abstract class Product
    {
        
    }

    public class ConcreteProductA : Product
    {
        
    }

    public class ConcreteProductB : Product
    {
        
    }

    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }
}
