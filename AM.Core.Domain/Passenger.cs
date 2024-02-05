using System;
namespace AM.Core.Domain
{
	public class Passenger
	{
        public DateTime BirthDate { get; set; }

        public string PasseportNumber { get; set; }

        public string EmailAdress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelNumber { get; set; }

        public IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate:" + BirthDate
                + "PasseportNumber:" + PasseportNumber
                + "EmailAdress:" + EmailAdress
                + "FirstName:" + FirstName
                + "LastName:" + LastName
                + "TelNumber:" + TelNumber;
        }
    }
}

