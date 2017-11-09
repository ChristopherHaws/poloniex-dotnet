using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Poloniex.Models
{
	public class PoloniexOrder
	{
		/// <summary>
		/// Returned order number from Poloniex. Successfull orders will have order number greater than zero
		/// </summary>
		[JsonProperty("orderNumber")]
		public Int64 OrderNumber { get; set; }

		[JsonProperty("resultingTrades")]
		public List<ResultingTrade> ResultingTrades { get; set; }
	}

	public class ResultingTrade
	{
		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("total")]
		public Decimal Total { get; set; }

		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("rate")]
		public Decimal Rate { get; set; }

		[JsonProperty("tradeID")]
		public String TradeId { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }
	}
}
