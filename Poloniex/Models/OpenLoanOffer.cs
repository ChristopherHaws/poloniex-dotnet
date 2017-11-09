using System;
using Newtonsoft.Json;

namespace Poloniex
{
	public class OpenLoanOffer
	{
		[JsonProperty("id")]
		public Int32 Id { get; set; }

		[JsonIgnore]
		public String Symbol { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("duration")]
		public Int32 Duration { get; set; }

		[JsonProperty("rate")]
		public Decimal Rate { get; set; }

		[JsonProperty("autoRenew")]
		public Boolean AutoRenew { get; set; }
	}
}
