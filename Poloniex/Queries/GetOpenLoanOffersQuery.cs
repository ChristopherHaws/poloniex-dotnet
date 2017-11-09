using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetOpenLoanOffersQuery
	{
		public static async Task<IList<OpenLoanOffer>> GetOpenLoanOffersAsync(this PoloniexClient client)
		{
			Dictionary<String, OpenLoanOffer[]> CustomDeserializer(String value)
			{
				if (value == "[]")
				{
					return new Dictionary<String, OpenLoanOffer[]>();
				}

				return JsonConvert.DeserializeObject<Dictionary<String, OpenLoanOffer[]>>(value);
			}

			var response = await client.SendRequestAsync(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnOpenLoanOffers"
			}, CustomDeserializer);

			return response.SelectMany(x =>
			{
				foreach (var value in x.Value)
				{
					value.Symbol = x.Key;
				}

				return x.Value;
			}).ToList();
		}

	
	}
}
