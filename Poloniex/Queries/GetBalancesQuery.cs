using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poloniex
{
	public static class GetBalancesQuery
	{
		public static async Task<IDictionary<String, String>> GetBalancesAsync(this PoloniexClient clien)
		{
			return await clien.SendRequestAsync<Dictionary<String, String>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnBalances"
			});
		}
	}
}
