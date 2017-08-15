using System;
using System.Collections.Specialized;

namespace Poloniex
{
	public class PoloniexRequest
	{
		public PoloniexApi Api { get; set; }
		public String Command { get; set; }
		public NameValueCollection Parameters { get; } = new NameValueCollection();
	}
}
