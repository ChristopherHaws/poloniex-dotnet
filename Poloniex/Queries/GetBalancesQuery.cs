using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Poloniex
{
	public static class GetBalancesQuery
	{
		public static async Task<IDictionary<String, Decimal>> GetBalancesAsync(this PoloniexClient clien)
		{
			return await clien.SendRequestAsync<Dictionary<String, Decimal>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnBalances"
			});
		}
	}
}
