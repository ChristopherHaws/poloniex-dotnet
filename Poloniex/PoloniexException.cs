using System;

namespace Poloniex
{
	public class PoloniexException : Exception
	{
		public PoloniexException(String message)
			: base(message)
		{
		}
	}
}
