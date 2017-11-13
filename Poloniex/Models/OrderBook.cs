using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Poloniex.Converters;

namespace Poloniex 
{
	public class OrderBook
    {
	    [JsonProperty("asks")]
	    public List<OrderBookEntry> Asks { get; set; }

	    [JsonProperty("bids")]
		public List<OrderBookEntry> Bids { get; set; }

	    [JsonProperty("isFrozen")]
	    [JsonConverter(typeof(BooleanConverter))]
		public Boolean IsFrozen { get; set; }

	    [JsonProperty("seq")]
	    public Int64 Sequence { get; set; }
	}

	public class OrderBookEntry
	{
		public decimal PriceLevel { get; set; }
		public decimal Volume { get; set; }
	}
}
