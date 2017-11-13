using System;

namespace Poloniex
{
	public class AvailableAccountBalance
	{
		public String Symbol { get; set; }

		public Decimal Exchange { get; set; }

		public Decimal Margin { get; set; }

		public Decimal Lending { get; set; }
	}
}
