using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex.Queries
{
	public static class GetDepositWithdrawalQuery
    {
		public static async Task<IList<DepositWithdrawal>> GetDepositWithdrawalQueryAsync(this PoloniexClient clien, DateTime? start = null, DateTime? end = null)
		{
			var response = await clien.SendRequestAsync<Dictionary<String, DepositWithdrawal[]>>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "returnDepositsWithdrawals",
				Parameters =
				{
					{"start", start?.ToUnixTimestamp().ToString()},
					{"end", end?.ToUnixTimestamp().ToString()},
				}
			});

			return response.SelectMany(x =>
			{
				foreach (var value in x.Value)
				{
					value.Type = x.Key;
				}

				return x.Value;
			}).ToList();
		}

		public class DepositWithdrawal
		{
			[JsonProperty("txid")]
			public String TxId { get; set; }

			[JsonProperty("currency")]
			public String Symbol { get; set; }

			[JsonIgnore]
			public String Type { get; set; }

			[JsonIgnore]
			public DateTime Date { get; set; }

			[JsonProperty("timestamp")]
			private ulong TimeStamp
			{
				set { this.Date = ExtensionMethods.FromUnixTimestamp(value); }
			}
			[JsonProperty("amount")]
			public Decimal Amount { get; set; }

			[JsonProperty("fee")]
			public Decimal Fees { get; set; }
			
		}
	}
}
