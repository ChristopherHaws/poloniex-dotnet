using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Poloniex
{
	public static class WithdrawCommand
	{
		/// <summary>
		/// Immediately places a withdrawal for a given currency, with no email confirmation. In order to use this method, the withdrawal privilege must be enabled for your API key. 
		/// </summary>
		/// <param name="client">Poloniex client</param>
		/// <param name="currency">Currency</param>
		/// <param name="amount">Amount to be withdrawn</param>
		/// <param name="address">Destination address</param>
		/// <param name="paymentId">For XMR withdrawals, you may optionally specify "paymentId"</param>
		/// <returns>Withdrawal response</returns>
		public static async Task<WithdrawResponse> WidthdrawCommandAsync(this PoloniexClient client, String currency, Decimal amount, String address, String paymentId)
		{

			var request = new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = "withdraw",
				Parameters =
				{
					{"currency", currency},
					{"amount", amount.ToString(CultureInfo.InvariantCulture)},
					{"address", address} 
				}
			};

			if (!string.IsNullOrEmpty(paymentId))
			{
				request.Parameters.Add("paymentId", paymentId);
			}

			return await client.SendRequestAsync<WithdrawResponse>(request).ConfigureAwait(false);
		}


		/// <summary>
		/// Immediately places a withdrawal for a given currency, with no email confirmation. In order to use this method, the withdrawal privilege must be enabled for your API key. 
		/// </summary>
		/// <param name="client">Poloniex client</param>
		/// <param name="currency">Currency</param>
		/// <param name="amount">Amount to be withdrawn</param>
		/// <param name="address">Destination address</param> 
		/// <returns>Withdrawal response</returns>
		public static async Task<WithdrawResponse> WidthdrawCommandAsync(this PoloniexClient client, String currency, Decimal amount, String address)
		{
			return await WidthdrawCommandAsync(client, currency, amount, address, null).ConfigureAwait(false);
		}
	}
}
