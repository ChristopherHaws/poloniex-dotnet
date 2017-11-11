using System;
using Newtonsoft.Json;

namespace Poloniex.Converters
{

	public class OrderBookEntryConverter : JsonConverter
	{

		private static readonly RuntimeTypeHandle OrderBookEntryTypeHandle;

		static OrderBookEntryConverter()
		{
			OrderBookEntryTypeHandle = typeof(OrderBookEntry).TypeHandle;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.StartArray)
			{
				return null;
			}

			var entry = new OrderBookEntry
			{
				// ReSharper disable once PossibleInvalidOperationException
				PriceLevel = reader.ReadAsDecimal().Value,
				// ReSharper disable once PossibleInvalidOperationException
				Volume = reader.ReadAsDecimal().Value
			};

			reader.Read();
			return entry;
		}

		public override bool CanConvert(Type objectType)
		{
			// ReSharper disable once ImpureMethodCallOnReadonlyValueField
			return OrderBookEntryTypeHandle.Equals(objectType.TypeHandle);
		}
	}
}
