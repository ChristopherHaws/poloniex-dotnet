using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetTickersQuery
	{
		public static async Task<IDictionary<String, Ticker>> GetTickersAsync(this PoloniexClient clien)
		{
			return await clien.SendRequestAsync<Dictionary<String, Ticker>>(new PoloniexRequest
			{
				Api = PoloniexApi.Public,
				Command = "returnTicker"
			});
		}

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
}
