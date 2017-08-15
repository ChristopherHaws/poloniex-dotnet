using System;
using Newtonsoft.Json;

namespace Poloniex
{
	public class PoloniexError
	{
		[JsonProperty("error")]
		public String Message { get; set; }
	}
}
