using System;
using Newtonsoft.Json;

namespace Poloniex 
{
	public class CompleteBalance
	{
		[JsonIgnore]
		public String Symbol { get; set; }

		[JsonProperty("available")]
		public Decimal Available { get; set; }

		[JsonProperty("onOrder")]
		public Decimal OnOrder { get; set; }

		[JsonProperty("btcValue")]
		public Decimal BtcValue { get; set; }
	}
}
