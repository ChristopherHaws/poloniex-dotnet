using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetCompleteBalancesQuery
	{
		public static async Task<IList<CompleteBalance>> GetCompleteBalancesAsync(this PoloniexClient clien)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, CompleteBalance>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnCompleteBalances"
			});

			foreach (var key in response.Keys)
			{
				response[key].Symbol = key;
			}

			return response.Values.ToList();
		}

		public class CompleteBalance
		{
			[JsonIgnore]
			public String Symbol { get; set; }

			[JsonProperty("available")]
			public Decimal Available { get; set; }

			[JsonProperty("onOrder")]
			public Decimal OnOrder { get; set; }

			[JsonProperty("btcValue")]
			public Decimal BtcValue { get; set; }
		}
	}
}
