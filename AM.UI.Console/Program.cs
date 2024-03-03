// See https://aka.ms/new-console-template for more information

using AM.Core.Domain;

Console.WriteLine("Hello, World !");
//constructeur par defaut
var plane = new Plane();
plane.Capacity = 120;
plane.ManufactureDate = DateTime.Now;
plane.MyPlaneType = PlaneType.Boing;
//constructeur parametrè
var plane1 = new Plane(5, DateTime.Now, PlaneType.Airbus);
//initiallisation d objet
var plane2 = new Plane { Capacity = 77, MyPlaneType = PlaneType.Airbus };
Console.WriteLine(plane);
Console.WriteLine(plane1);
Console.WriteLine(plane2);
var passenger = new Passenger();
Passenger passenger1 = new Traveller();
Passenger passenger2 = new Staff();
Console.WriteLine(passenger.GetPassengerType());
Console.WriteLine(passenger1.GetPassengerType());
Console.WriteLine(passenger2.GetPassengerType());