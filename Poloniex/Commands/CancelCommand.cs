using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class CancelCommand
	{
		public static async Task<OrderCancellationResponse> CancelOrderAsync(this PoloniexClient client, String orderNumber)
		{
			return await client.SendRequestAsync<OrderCancellationResponse>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "cancelOrder",
				Parameters =
				{
					{"orderNumber", orderNumber}
				}
			}).ConfigureAwait(false);
		}
	}

	
}
