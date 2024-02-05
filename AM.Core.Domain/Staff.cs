using System;
using System.Numerics;

namespace AM.Core.Domain
{
	public class Staff : Passenger
	{
        public DateTime EmployementDate { get; set; }

        public string Function { get; set; }

        public int Salary { get; set; }

        public override string ToString()
        {
            return base.ToString()+ "EmployementDate:" + EmployementDate
                + "Function:" + Function
                + "Salary:" + Salary;
                

        }
    }
}

