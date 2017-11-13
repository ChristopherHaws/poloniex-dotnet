using System;
using Newtonsoft.Json;

namespace Poloniex 
{
	public class ActiveLoan
	{
		[JsonProperty("id")]
		public Int32 Id { get; set; }

		[JsonProperty("currency")]
		public String Symbol { get; set; }

		[JsonIgnore]
		public String Status { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("fees")]
		public Decimal Fees { get; set; }

		[JsonProperty("rate")]
		public Decimal Rate { get; set; }

		[JsonProperty("autoRenew")]
		public Boolean AutoRenew { get; set; }

		[JsonProperty("range")]
		public String Range { get; set; }
	}
}
