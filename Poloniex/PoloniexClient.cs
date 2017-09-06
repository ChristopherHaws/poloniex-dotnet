using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Poloniex
{
	public class PoloniexClient
	{
		private readonly String apiKey;
		private readonly String secret;

		public PoloniexClient(String apiKey, String secret)
		{
			this.apiKey = apiKey;
			this.secret = secret;
		}

		public async Task<T> SendRequestAsync<T>(PoloniexRequest request, Func<String, T> customDeserializer = null)
		{
			using (var client = new HttpClient())
			{
				var requestMessage = request.Api == PoloniexApi.Trading
					? await this.BuildAuthenticatedRequestAsync(request)
					: this.BuildUnauthenticatedRequestAsync(request);
				
				var response = await client.SendAsync(requestMessage);
				var content = await response.Content.ReadAsStringAsync();

				if (!response.IsSuccessStatusCode)
				{
					var error = JsonConvert.DeserializeObject<PoloniexError>(content);

					throw new PoloniexException(error.Message);
				}

				return (customDeserializer != null)
					? customDeserializer.Invoke(content)
					: JsonConvert.DeserializeObject<T>(content);
			}
		}

		private HttpRequestMessage BuildUnauthenticatedRequestAsync(PoloniexRequest request)
		{
			var builder = new UriBuilder("https://poloniex.com/public")
			{
				Query = new NameValueCollection
				{
					{ "command", request.Command },
					request.Parameters
				}.ToQueryString()
			};

			return new HttpRequestMessage(HttpMethod.Get, builder.Uri);
		}

		private async Task<HttpRequestMessage> BuildAuthenticatedRequestAsync(PoloniexRequest request)
		{
			var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://poloniex.com/tradingApi")
			{
				Content = new NameValueCollection
				{
					{ "command", request.Command },
					{ "nonce", (DateTime.UtcNow.ToUnixTimestamp() * 100000).ToString() },
					request.Parameters
				}.ToFormUrlEncodedContent()
			};

			var body = await requestMessage.Content.ReadAsStringAsync();
			var hash = this.HashString(this.secret, body);

			requestMessage.Headers.Add("Key", this.apiKey);
			requestMessage.Headers.Add("Sign", hash);

			return requestMessage;
		}

		private String HashString(String secret, String value)
		{
			var secretBytes = Encoding.UTF8.GetBytes(secret);
			var valueBytes = Encoding.UTF8.GetBytes(value);

			using (var hmac = new HMACSHA512(secretBytes))
			{
				var hash = hmac.ComputeHash(valueBytes);

				return hash.ToHexString();
			}
		}
	}
}
