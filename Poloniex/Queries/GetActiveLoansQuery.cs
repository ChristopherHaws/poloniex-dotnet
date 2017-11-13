using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetActiveLoansQuery
	{
		public static async Task<IList<ActiveLoan>> GetActiveLoansAsync(this PoloniexClient clien)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, ActiveLoan[]>> (new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnActiveLoans"
			});

			return response.SelectMany(x =>
			{
				foreach (var value in x.Value)
				{
					value.Status = x.Key;
				}

				return x.Value;
			}).ToList();
		}
	
	}
}
