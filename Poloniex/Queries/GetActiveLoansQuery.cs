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

		public class ActiveLoan
		{
			[JsonProperty("id")]
			public Int32 Id { get; set; }

			[JsonProperty("currency")]
			public String Symbol { get; set; }

			[JsonIgnore]
			public String Status { get; set; }

			[JsonProperty("date")]
			public DateTime Date { get; set; }

			[JsonProperty("amount")]
			public Decimal Amount { get; set; }

			[JsonProperty("fees")]
			public Decimal Fees { get; set; }

			[JsonProperty("rate")]
			public Decimal Rate { get; set; }

			[JsonProperty("autoRenew")]
			public Boolean AutoRenew { get; set; }

			[JsonProperty("range")]
			public String Range { get; set; }
		}
	}
}
