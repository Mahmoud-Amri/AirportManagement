﻿
// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;

Console.WriteLine("Hello, World !");
//constructeur par defaut
Plane plane = new Plane();
plane.Capacity = 120;
plane.ManufactureDate = DateTime.Now;
plane.MyPlaneType = PlaneType.Boing;
//constructeur parametrè
Plane plane1 = new Plane( 5, DateTime.Now, PlaneType.Airbus);
//initiallisation d objet
Plane plane2 = new Plane() { Capacity = 77, MyPlaneType = PlaneType.Airbus };
Console.WriteLine(plane);
Console.WriteLine(plane1);
Console.WriteLine(plane2);
