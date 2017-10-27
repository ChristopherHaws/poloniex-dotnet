using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetDepositAddressesQuery
	{
		public static async Task<IList<DepositAddress>> GetDepositAddressesAsync(this PoloniexClient clien)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, String>> (new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnDepositAddresses"
			});

			return response.Select(x => new DepositAddress()
			{
				Symbol = x.Key,
				Address = x.Value
			}).ToList();
		}

		public class DepositAddress
		{
			public String Symbol { get; set; }

			public String Address { get; set; }
		}
	}
}
