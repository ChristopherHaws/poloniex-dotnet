using System;
using System.Collections.Generic;
using System.Globalization;
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
				return value == "[]" ? new Dictionary<String, Trade[]>() : JsonConvert.DeserializeObject<Dictionary<String, Trade[]>>(value);
			}

			var response = await client.SendRequestAsync(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnTradeHistory",
				Parameters =
				{
					{"currencyPair", "all"},
					{"start", start?.ToUnixTimestamp().ToString(CultureInfo.InvariantCulture)},
					{"end", end?.ToUnixTimestamp().ToString(CultureInfo.InvariantCulture)},
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
					{"start", start?.ToUnixTimestamp().ToString(CultureInfo.InvariantCulture)},
					{"end", end?.ToUnixTimestamp().ToString(CultureInfo.InvariantCulture)},
					{"limit", limit?.ToString()}
				}
			});

			foreach (var trade in trades)
			{
				trade.CurrencyPair = currencyPair;
			}

			return trades;
		}

	
	}
}
