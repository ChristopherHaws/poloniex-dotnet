using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex.Queries
{
	public static class GetTradeHistoryQuery
	{
		public static async Task<IList<Trade>> GetTradeHistory(this PoloniexClient client, DateTime? start = null, DateTime? end = null, Int32? limit = null)
		{
			Dictionary<String, Trade[]> CustomDeserializer(String value)
			{
				if (value == "[]")
				{
					return new Dictionary<String, Trade[]>();
				}

				return JsonConvert.DeserializeObject<Dictionary<String, Trade[]>>(value);
			}

			var response = await client.SendRequestAsync<Dictionary<String, Trade[]>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnTradeHistory",
				Parameters =
				{
					{"currencyPair", "all"},
					{"start", start?.ToUnixTimestamp().ToString()},
					{"end", end?.ToUnixTimestamp().ToString()},
					{"limit", limit?.ToString()}
				}
			}, CustomDeserializer);

			return response.SelectMany(x =>
			{
				foreach (var value in x.Value)
				{
					value.CurrencyPair = x.Key;
				}

				return x.Value;
			}).ToList();
		}

		public static async Task<IList<Trade>> GetTradeHistory(this PoloniexClient client, String currencyPair, DateTime? start = null, DateTime? end = null, Int32? limit = null)
		{
			var trades = await client.SendRequestAsync<Trade[]>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnTradeHistory",
				Parameters =
				{
					{"currencyPair", currencyPair},
					{"start", start?.ToUnixTimestamp().ToString()},
					{"end", end?.ToUnixTimestamp().ToString()},
					{"limit", limit?.ToString()}
				}
			});

			foreach (var trade in trades)
			{
				trade.CurrencyPair = currencyPair;
			}

			return trades;
		}

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
}
