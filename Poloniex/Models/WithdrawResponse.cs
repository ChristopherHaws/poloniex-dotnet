using Newtonsoft.Json;

namespace Poloniex 
{
	public class WithdrawResponse
	{
		[JsonProperty("response")]
		public string Response { get; set; }
	}
}
