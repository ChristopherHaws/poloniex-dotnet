using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poloniex
{
	public static class GetAvailableAccountBalancesQuery
	{
		public static async Task<IList<AvailableAccountBalance>> GetAvailableAccountBalancesAsync(this PoloniexClient clien)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, Dictionary< String, Decimal >>> (new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnAvailableAccountBalances"
			});

			var balances = new List<AvailableAccountBalance>();

			foreach (var account in response)
			{
				foreach (var symbol in account.Value)
				{
					var balance = balances.FirstOrDefault(x => x.Symbol.Equals(symbol.Key, StringComparison.OrdinalIgnoreCase));
					if (balance == null)
					{
						balance = new AvailableAccountBalance()
						{
							Symbol = symbol.Key
						};
						balances.Add(balance);
					}

					switch (account.Key.ToLower())
					{
						case "exchange":
							balance.Exchange += symbol.Value;
							break;
						case "margin":
							balance.Exchange += symbol.Value;
							break;
						case "lending":
							balance.Exchange += symbol.Value;
							break;
					}
				}
			}

			return balances;
		}
	}
}
