using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poloniex
{
	public static class GetOrderBookQuery
	{
		public static async Task<OrderBook> GetOrderBookAsync(this PoloniexClient client, String currencyPair, UInt32 depth)
		{
			var request = new PoloniexRequest
			{
				Api = PoloniexApi.Public,
				Command = "returnOrderBook",
				Parameters = {
					{"currencyPair", "BTC_ETH"},
					{"depth", depth.ToString()}
				}
			}; 
			return await client.SendRequestAsync<OrderBook>(request); 
		}

		public static async Task<OrderBook> GetOrderBookAsync(this PoloniexClient client, String currencyPair )
		{
			var request = new PoloniexRequest
			{
				Api = PoloniexApi.Public,
				Command = "returnOrderBook",
				Parameters = {
					{"currencyPair", "BTC_ETH"} 
				}
			};
			return await client.SendRequestAsync<OrderBook>(request);
		}



		public static async Task<Dictionary<string, OrderBook>> GetOrderBooksAsync(this PoloniexClient client,   UInt32 depth)
		{
			var request = new PoloniexRequest
			{
				Api = PoloniexApi.Public,
				Command = "returnOrderBook",
				Parameters = {
					{"currencyPair", "all"},
					{"depth", depth.ToString()}
				}
			};
			return await client.SendRequestAsync<Dictionary<string, OrderBook>>(request);
		}

		public static async Task<Dictionary<string, OrderBook>> GetOrderBooksAsync(this PoloniexClient client)
		{ 
			var request = new PoloniexRequest
			{
				Api = PoloniexApi.Public,
				Command = "returnOrderBook",
				Parameters = {
					{"currencyPair", "all"}
				}
			};
			return await client.SendRequestAsync<Dictionary<string, OrderBook>>(request);
		}
	}
}
