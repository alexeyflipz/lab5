using System;
using System.Collections.Generic;

abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }
    public int CurrentPassengers { get; set; }

    public abstract void Move(string startPoint, string endPoint);
    public void BoardPassengers(int passengers)
    {
        if (CurrentPassengers + passengers <= Capacity)
        {
            CurrentPassengers += passengers;
            Console.WriteLine($"{passengers} passengers boarded. Total: {CurrentPassengers}/{Capacity}");
        }
        else
        {
            Console.WriteLine("Not enough space for all passengers!");
        }
    }

    public void DisembarkPassengers(int passengers)
    {
        if (passengers <= CurrentPassengers)
        {
            CurrentPassengers -= passengers;
            Console.WriteLine($"{passengers} passengers disembarked. Total: {CurrentPassengers}/{Capacity}");
        }
        else
        {
            Console.WriteLine("Not enough passengers to disembark!");
        }
    }
}

class Car : Vehicle
{
    public Car()
    {
        Speed = 120;
        Capacity = 4;
    }

    public override void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Car moving from {startPoint} to {endPoint} at speed {Speed} km/h.");
    }
}

class Bus : Vehicle
{
    public Bus()
    {
        Speed = 80;
        Capacity = 50;
    }

    public override void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Bus moving from {startPoint} to {endPoint} at speed {Speed} km/h.");
    }
}

class Train : Vehicle
{
    public Train()
    {
        Speed = 60;
        Capacity = 300;
    }

    public override void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Train moving from {startPoint} to {endPoint} at speed {Speed} km/h.");
    }
}

class Human
{
    public int Speed { get; set; }

    public Human(int speed)
    {
        Speed = speed;
    }

    public void Move(string startPoint, string endPoint)
    {
        Console.WriteLine($"Human walking from {startPoint} to {endPoint} at speed {Speed} km/h.");
    }
}

class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string startPoint, string endPoint)
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public string CalculateOptimalRoute(Vehicle vehicle)
    {
        return $"{vehicle.GetType().Name} will take the optimal route from {StartPoint} to {EndPoint}.";
    }
}

class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"{vehicle.GetType().Name} added to the network.");
    }

    public void ControlMovement(string startPoint, string endPoint)
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move(startPoint, endPoint);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        Bus bus = new Bus();
        Train train = new Train();

        Human pedestrian = new Human(5);

        TransportNetwork network = new TransportNetwork();
        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        Route route = new Route("A", "B");

        Console.WriteLine(route.CalculateOptimalRoute(car));

        network.ControlMovement(route.StartPoint, route.EndPoint);

        bus.BoardPassengers(30);
        bus.DisembarkPassengers(10);

        pedestrian.Move("A", "B");
    }
}