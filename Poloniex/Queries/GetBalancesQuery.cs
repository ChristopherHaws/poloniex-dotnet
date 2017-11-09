using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetBalancesQuery
	{
		public static async Task<IList<AvailableBalance>> GetBalancesAsync(this PoloniexClient clien)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, Decimal>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnBalances"
			});

			return response.Select(x => new AvailableBalance()
			{
				Symbol = x.Key,
				Available = x.Value
			}).ToList();
		} 
		
	}
}
