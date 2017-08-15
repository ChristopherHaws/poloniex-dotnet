using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Poloniex
{
	internal static class ExtensionMethods
	{
		public static Double ToUnixTimestamp(this DateTime dateTime)
		{
			return (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		}

		public static String ToHexString(this Byte[] value)
		{
			var hex = new StringBuilder(value.Length * 2);

			foreach (var b in value)
			{
				hex.AppendFormat("{0:x2}", b);
			}

			return hex.ToString();
		}

		public static String ToQueryString(this NameValueCollection nvc)
		{
			var array = (
				from key in nvc.AllKeys
				from value in nvc.GetValues(key)
				//FIXME: I didnt want to depend on Microsoft.AspNet.WebUtilities to get WebUtility.UrlEncode since this should be internal anyways.
				//select String.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))
				select String.Format("{0}={1}", key, value)
			).ToArray();

			return String.Join("&", array);
		}

		public static FormUrlEncodedContent ToFormUrlEncodedContent(this NameValueCollection values)
		{
			IEnumerable<KeyValuePair<String, String>> EnumerableValues()
			{
				foreach (var key in values.AllKeys)
				{
					yield return new KeyValuePair<String, String>(key, values[key]);
				}
			}

			return new FormUrlEncodedContent(EnumerableValues());
		}
	}
}
