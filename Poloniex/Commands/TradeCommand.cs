using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public static class TradeCommand
	{
	 
		private static async Task<PoloniexOrder> PlaceTradeOrderAsync(this PoloniexClient client, String command,  String currencyPair, Decimal rate, Decimal amount, Boolean fillOrKill, Boolean immediateOrCancel, Boolean postOnly)
		{
			return await client.SendRequestAsync<PoloniexOrder>(new PoloniexRequest
			{
				Api = PoloniexApi.Trading,
				Command = command,
				Parameters =
				{
					{"currencyPair", currencyPair},
					{"rate", rate.ToString(CultureInfo.InvariantCulture) },
					{"amount", amount.ToString(CultureInfo.InvariantCulture)},
					{"fillOrKill", Convert.ToInt16(fillOrKill).ToString()  },
					{"immediateOrCancel", Convert.ToInt16(immediateOrCancel).ToString() },
					{ "postOnly", Convert.ToInt16(postOnly).ToString() }
				}
			}).ConfigureAwait(false); 
		}



		/// <summary>
		/// Places buy command
		/// </summary>
		/// <param name="client">Poloniex client</param>
		/// <param name="currencyPair">Currency pair in the format of XXX_YYY</param>
		/// <param name="rate">Rate at which the order should be placed at</param>
		/// <param name="amount">The amount for which the order should placed</param>
		/// <param name="fillOrKill">A fill-or-kill order will either fill in its entirety or be completely aborted.</param>
		/// <param name="immediateOrCancel">An immediate-or-cancel order can be partially or completely filled, but any portion of the order that cannot be filled immediately will be canceled rather than left on the order book.</param>
		/// <param name="postOnly">A post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills.</param>
		/// <returns></returns>
		public static async Task<PoloniexOrder> BuyCommandAsync(this PoloniexClient client,  String currencyPair, Decimal rate, Decimal amount, Boolean fillOrKill, Boolean immediateOrCancel, Boolean postOnly)
		{
			return await PlaceTradeOrderAsync(client, "buy", currencyPair, rate, amount, fillOrKill, immediateOrCancel, postOnly);
		}


		/// <summary>
		/// Places buy command
		/// </summary>
		/// <param name="client">Poloniex client</param>
		/// <param name="currencyPair">Currency pair in the format of XXX_YYY</param>
		/// <param name="rate">Rate at which the order should be placed at</param>
		/// <param name="amount">The amount for which the order should placed</param>
		/// <returns></returns>
		public static async Task<PoloniexOrder> BuyCommandAsync(this PoloniexClient client, String currencyPair, Decimal rate, Decimal amount)
		{
			return await BuyCommandAsync(client, currencyPair, rate, amount, false, false, false);
		}




		/// <summary>
		/// Places buy command
		/// </summary>
		/// <param name="client">Poloniex client</param>
		/// <param name="currencyPair">Currency pair in the format of XXX_YYY</param>
		/// <param name="rate">Rate at which the order should be placed at</param>
		/// <param name="amount">The amount for which the order should placed</param>
		/// <param name="fillOrKill">A fill-or-kill order will either fill in its entirety or be completely aborted.</param>
		/// <param name="immediateOrCancel">An immediate-or-cancel order can be partially or completely filled, but any portion of the order that cannot be filled immediately will be canceled rather than left on the order book.</param>
		/// <param name="postOnly">A post-only order will only be placed if no portion of it fills immediately; this guarantees you will never pay the taker fee on any part of the order that fills.</param>
		/// <returns></returns>
		public static async Task<PoloniexOrder> SellCommandAsync(this PoloniexClient client, String currencyPair, Decimal rate, Decimal amount, Boolean fillOrKill, Boolean immediateOrCancel, Boolean postOnly)
		{
			return await PlaceTradeOrderAsync(client, "sell", currencyPair, rate, amount, fillOrKill, immediateOrCancel, postOnly);
		}


		/// <summary>
		/// Places buy command
		/// </summary>
		/// <param name="client">Poloniex client</param>
		/// <param name="currencyPair">Currency pair in the format of XXX_YYY</param>
		/// <param name="rate">Rate at which the order should be placed at</param>
		/// <param name="amount">The amount for which the order should placed</param>
		/// <returns></returns>
		public static async Task<PoloniexOrder> SellCommandAsync(this PoloniexClient client, String currencyPair, Decimal rate, Decimal amount)
		{
			return await SellCommandAsync(client, currencyPair, rate, amount, false, false, false);
		} 

	}
	 

}
