﻿using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain;

public class Staff : Passenger
{
    public DateTime EmployementDate { get; set; }

   
    
    public string Function { get; set; }

    [DataType(DataType.Currency)]
    public int Salary { get; set; }

    public override string ToString()
    {
        return base.ToString() + "EmployementDate:" + EmployementDate
               + "Function:" + Function
               + "Salary:" + Salary;
    }

    public override string GetPassengerType()
    {
        return "I'm a Staff";
    }
}