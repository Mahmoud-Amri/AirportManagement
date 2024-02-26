using System;
using System.Numerics;

namespace AM.Core.Domain
{
	public class Passenger
	{
        public DateTime BirthDate { get; set; }

        private int age;

        public int Age
        {
            get
            {
              if  ( DateTime.Now < BirthDate.AddYears(age))
                { age--; }

                return age;
            }
        }

        public string PasseportNumber { get; set; }

        public string EmailAdress { get; set; }
        
        public int PassengerId { get; set; }


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

        public bool CheckProfile(string FirstName, string LastName)
        {
            return this.FirstName == FirstName && this.LastName == LastName;
        }
        public bool CheckProfile(string FirstName, string LastName, string EmailAdress=null)
        {
            if (EmailAdress == null)
            {
                return this.FirstName == FirstName && this.LastName == LastName;
            }
            else
            {
                return this.FirstName == FirstName && this.LastName == LastName && this.EmailAdress == EmailAdress;

            }
        }

        public virtual string GetPassengerType()
        {
                    {
                return "I'm a passenger";
                     }
             
            
        }
    }

}

