using System;
namespace AM.Core.Domain
{
	public class Plane
	{
		public int Capacity { get; set; }

		public DateTime ManufactureDate { get; set; }

		public int PlaneId { get; set; }

		public PlaneType MyPlaneType { get; set; }

        public IList<Flight> Flights { get; set; }


        public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            MyPlaneType = planeType;
        }

        public Plane()
        {
        }

        public override string ToString()
        {
            return "Capacity:" + Capacity
                + "ManufactureDate:" + ManufactureDate
                + "PlaneId:" + PlaneId
                + "PlaneType:" + MyPlaneType;
               
        }


    }
}

