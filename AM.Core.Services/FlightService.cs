using System;
using AM.Core.Domain;

namespace AM.Core.Services
{
	public class FlightService :IFlightService
	{
		public IList<Flight> flights { get; set; }
	}
}

