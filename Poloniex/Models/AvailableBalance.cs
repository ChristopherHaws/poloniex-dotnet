using System;
using Newtonsoft.Json;

namespace Poloniex 
{
	public class AvailableBalance
	{
		public String Symbol { get; set; }

		[JsonProperty("available")]
		public Decimal Available { get; set; }
	}
}
