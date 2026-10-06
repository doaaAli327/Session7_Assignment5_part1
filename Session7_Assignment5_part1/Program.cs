using System;

namespace Session7_Assignment5_part1
{
    // -------------------------------- Part 1: Interfaces --------------------------------
    // ---------------------- Q9 ----------------------
    public class CarQ9
    {
        public void MoveForward()
        {
            Console.WriteLine("Car is moving forward.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Car is moving backward.");
        }
    }

    /*
    -------------------------------------------------------------------------------------------------------------
    Q9 Problem Answer:
    -------------------------------------------------------------------------------------------------------------
    Forcing every vehicle to implement all four methods creates two main problems:

    1. ISP Violation: Classes are forced to implement methods they don't support (e.g., Cars cannot fly).
    2. Dummy Code: Classes must write empty methods or throw 'NotImplementedException'.

    Solution:
    Separate behaviors into smaller interfaces (IMoveable & IFlyable).
    -------------------------------------------------------------------------------------------------------------
    */

    // ---------------------- Q10 ----------------------
    public interface IMoveable
    {
        void MoveForward();
        void MoveBackward();
    }
    public interface IFlyable
    {
        void MoveUp();
        void MoveDown();
    }

    // ---------------------- Q11 ----------------------
    public class Car : IMoveable
    {
        public void MoveForward()
        {
            Console.WriteLine("Car is driving forward on the road.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Car is reversing on the road.");
        }
    }

    public class Ship : IMoveable
    {
        public void MoveForward()
        {
            Console.WriteLine("Ship is sailing forward in the sea.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Ship is sailing backward in the sea.");
        }
    }

    public class Airplane : IMoveable, IFlyable
    {
        public void MoveForward()
        {
            Console.WriteLine("Airplane is flying forward in the air.");
        }

        public void MoveBackward()
        {
            Console.WriteLine("Airplane is moving backward on the runway.");
        }

        public void MoveUp()
        {
            Console.WriteLine("Airplane is gaining altitude.");
        }

        public void MoveDown()
        {
            Console.WriteLine("Airplane is descending.");
        }
    }


    // ---------------------- Q13 ----------------------
    public interface IVehicle : IMoveable, IFlyable
    {
        // Inherits:
        // MoveForward()
        // MoveBackward()
        // MoveUp()
        // MoveDown()
    }

    public class Vehicle : IVehicle
    {
        public virtual void MoveForward()
        {
            Console.WriteLine("Vehicle is moving forward.");
        }

        public virtual void MoveBackward()
        {
            Console.WriteLine("Vehicle is moving backward.");
        }

        public virtual void MoveUp()
        {
            Console.WriteLine("Vehicle is moving up.");
        }

        public virtual void MoveDown()
        {
            Console.WriteLine("Vehicle is moving down.");
        }
    }


    // ---------------------- Q14 ----------------------
    // We use a different class name here only to avoid changing
    // the Ship class required in Q11 and Q12.
    public class ShipQ14 : IMoveable
    {
        // Explicit Interface Implementation
        void IMoveable.MoveForward()
        {
            Console.WriteLine("Ship is sailing forward in the sea (Explicit Implementation).");
        }

        // Normal implementation
        public void MoveBackward()
        {
            Console.WriteLine("Ship is sailing backward in the sea.");
        }
    }


    // ---------------------- Program ----------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------- Q9 Testing ----------------------
            Console.WriteLine("--------------------- Q9 Test ---------------------");

            CarQ9 carQ9 = new CarQ9();
            carQ9.MoveForward();
            carQ9.MoveBackward();


            // ---------------------- Q12 ----------------------
            Console.WriteLine("\n--------------------- Q12 ---------------------");

            // 1. Using Concrete Types
            Console.WriteLine("=== Concrete Types ===");

            Car myCar = new Car();
            myCar.MoveForward();
            myCar.MoveBackward();

            Ship myShip = new Ship();
            myShip.MoveForward();
            myShip.MoveBackward();

            Airplane myPlane = new Airplane();
            myPlane.MoveForward();
            myPlane.MoveBackward();
            myPlane.MoveUp();
            myPlane.MoveDown();


            // 2. Using Interface References
            Console.WriteLine("\n=== Interface References ===");

            IMoveable carRef = new Car();
            carRef.MoveForward();
            carRef.MoveBackward();

            IMoveable planeRef = new Airplane();
            planeRef.MoveForward();
            planeRef.MoveBackward();

            // planeRef.MoveUp();
            // Compilation Error:
            // IMoveable does not contain MoveUp().

            // Correct reference type:
            IFlyable flyablePlane = new Airplane();
            flyablePlane.MoveUp();
            flyablePlane.MoveDown();


            /*
            -------------------------------------------------------------------------------------------------------------
            Q12 Answer:
            -------------------------------------------------------------------------------------------------------------
            No, MoveUp() cannot be called using planeRef because planeRef is declared as IMoveable.

            IMoveable only contains:
            MoveForward()
            MoveBackward()

            To call MoveUp() and MoveDown(), we need an IFlyable reference.
            -------------------------------------------------------------------------------------------------------------
            */


            // ---------------------- Q13 Testing ----------------------
            Console.WriteLine("\n--------------------- Q13 ---------------------");

            IVehicle vehicle = new Vehicle();

            vehicle.MoveForward();
            vehicle.MoveBackward();
            vehicle.MoveUp();
            vehicle.MoveDown();


            /*
            -------------------------------------------------------------------------------------------------------------
            Q13 Answer:
            -------------------------------------------------------------------------------------------------------------
            Benefit of Interface Inheritance:

            1. Interface Aggregation:
               Combines multiple related interfaces into a single unified contract.

            2. Code Simplification:
               A class can implement IVehicle instead of separately implementing
               IMoveable and IFlyable.

            3. Polymorphism:
               Allows objects to be treated as IVehicle and use all combined behaviors.
            -------------------------------------------------------------------------------------------------------------
            */


            // ---------------------- Q14 Testing ----------------------
            Console.WriteLine("\n--------------------- Q14 ---------------------");

            ShipQ14 shipQ14 = new ShipQ14();

            // shipQ14.MoveForward();
            // Compilation Error:
            // MoveForward() is explicitly implemented,
            // so it cannot be called directly using ShipQ14 reference.

            // Correct way:
            IMoveable shipRef = shipQ14;

            shipRef.MoveForward();
            shipRef.MoveBackward();


            /*
            -------------------------------------------------------------------------------------------------------------
            Q14 Answer:
            -------------------------------------------------------------------------------------------------------------
            Yes, a class can implement IMoveable explicitly.

            With explicit implementation:

                void IMoveable.MoveForward()

            MoveForward() cannot be called directly using a ShipQ14 object.

            This will cause a compilation error:

                shipQ14.MoveForward();

            It must be called through an IMoveable reference:

                IMoveable shipRef = shipQ14;
                shipRef.MoveForward();

            -------------------------------------------------------------------------------------------------------------
            */
        }
    }
}