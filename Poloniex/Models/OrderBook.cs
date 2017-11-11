using System.Collections.Generic;
using Newtonsoft.Json;

namespace Poloniex 
{
	public class OrderBook
    {
	    [JsonProperty("asks")]
	    public List<OrderBookEntry> Asks { get; set; }

	    [JsonProperty("bids")]
		public List<OrderBookEntry> Bids { get; set; }

	    [JsonProperty("isFrozen")]
	    public long IsFrozen { get; set; }

	    [JsonProperty("seq")]
	    public long Sequence { get; set; }
	}

	public class OrderBookEntry
	{
		public decimal PriceLevel { get; set; }
		public decimal Volume { get; set; }
	}
}
