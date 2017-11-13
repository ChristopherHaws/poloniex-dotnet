using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Poloniex 
{
	[DebuggerDisplay("{id} - {last}")]
	public class Ticker
	{
		[JsonProperty("id")]
		public Int32 Id { get; set; }

		[JsonProperty("last")]
		public Decimal Last { get; set; }

		[JsonProperty("lowestAsk")]
		public Decimal LowestAsk { get; set; }

		[JsonProperty("highestBid")]
		public Decimal HighestBid { get; set; }

		[JsonProperty("percentChange")]
		public String PercentChange { get; set; }

		[JsonProperty("baseVolume")]
		public String BaseVolume { get; set; }

		[JsonProperty("quoteVolume")]
		public Decimal QuoteVolume { get; set; }

		[JsonProperty("isFrozen")]
		public String IsFrozen { get; set; }

		[JsonProperty("high24hr")]
		public Decimal High24hr { get; set; }

		[JsonProperty("low24hr")]
		public Decimal Low24hr { get; set; }
	}
} 
