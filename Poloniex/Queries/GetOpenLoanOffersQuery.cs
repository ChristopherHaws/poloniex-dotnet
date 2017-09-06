using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class GetOpenLoanOffersQuery
	{
		public static async Task<IList<OpenLoanOffer>> GetOpenLoanOffersAsync(this PoloniexClient clien)
		{
			Dictionary<String, OpenLoanOffer[]> CustomDeserializer(String value)
			{
				if (value == "[]")
				{
					return new Dictionary<String, OpenLoanOffer[]>();
				}

				return JsonConvert.DeserializeObject<Dictionary<String, OpenLoanOffer[]>>(value);
			}

			var response = await clien.SendRequestAsync<Dictionary<String, OpenLoanOffer[]>>(new PoloniexRequest
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

		public class OpenLoanOffer
		{
			[JsonProperty("id")]
			public Int32 Id { get; set; }

			[JsonIgnore]
			public String Symbol { get; set; }

			[JsonProperty("date")]
			public DateTime Date { get; set; }

			[JsonProperty("amount")]
			public Decimal Amount { get; set; }

			[JsonProperty("duration")]
			public Int32 Duration { get; set; }

			[JsonProperty("rate")]
			public Decimal Rate { get; set; }

			[JsonProperty("autoRenew")]
			public Boolean AutoRenew { get; set; }
		}
	}
}
