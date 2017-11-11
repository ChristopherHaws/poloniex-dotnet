using System;
using Newtonsoft.Json;

namespace Poloniex.Converters
{
	public class BooleanConverter : JsonConverter
	{
		public static readonly RuntimeTypeHandle BooleanTypeHandle;

		static BooleanConverter()
		{
			BooleanTypeHandle = typeof(Boolean).TypeHandle;
		}

		public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
		{
			writer.WriteValue((bool)value ? 1 : 0);
		}

		public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
		{
			return reader.Value.ToString().Equals("1");
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(bool);
		}
	}
}
