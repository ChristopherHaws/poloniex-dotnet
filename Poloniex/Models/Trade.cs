using System;
using Newtonsoft.Json;

namespace Poloniex
{
	public class Trade
	{
		[JsonIgnore]
		public String CurrencyPair { get; set; }

		[JsonProperty("globalTradeID")]
		public Int64 GlobalTradeId { get; set; }

		[JsonProperty("tradeID")]
		public Int64 TradeId { get; set; }

		[JsonProperty("orderNumber")]
		public Int64 OrderNumber { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("type")]
		public String Type { get; set; }

		[JsonProperty("amount")]
		public Decimal Amount { get; set; }

		[JsonProperty("fee")]
		public Decimal Fees { get; set; }

		[JsonProperty("rate")]
		public Decimal Rate { get; set; }

		[JsonProperty("total")]
		public Decimal Total { get; set; }

		[JsonProperty("category")]
		public String Category { get; set; }
	}
}
