using Newtonsoft.Json;

namespace Poloniex 
{
	public class OrderCancellationResponse
	{
		[JsonProperty("success")]
		public bool Success { get; set; }
	}
}
