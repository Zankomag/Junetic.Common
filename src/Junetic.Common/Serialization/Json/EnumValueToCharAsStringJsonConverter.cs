using JetBrains.Annotations;
using Junetic.Common.Extensions;
using Newtonsoft.Json;

namespace Junetic.Common.Serialization.Json;

//TODO Add unit tests
//todo add example in summary

/// <summary>
/// This converter must be applied only on Enums. Is converts enum value to a char and then to a string.
/// <para> It's useful for enums which has value representation as a char. </para>
/// </summary>
[PublicAPI]
public class EnumValueToCharAsStringJsonConverter : JsonConverter {

	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
		if(value is not Enum enumValue)
			throw new JsonSerializationException($"Unable to serialize value to \"{writer.Path}\" field. {(value is not null ? $"Value type is {value.GetType()}, but must be an enum" : "value is null")}");

		string result = enumValue.ValueToCharAsString();

		writer.WriteValue(result);
	}

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {
		if(!objectType.IsEnum)
			throw new JsonSerializationException($"Unable to deserialize \"{reader.Path}\" json value into {{{objectType}}} type, field type must be an enum");
		if(reader.Value is not string stringValue)
			throw new JsonSerializationException($"Unable to deserialize Json field \"{reader.Path}\" value to {objectType}. Token type is {reader.TokenType}, but must be a string");
		if(stringValue.Length != 1)
			throw new JsonSerializationException($"Unable to deserialize Json field \"{reader.Path}\" value to {objectType}. Value length is {stringValue.Length}, but string length must be equal to 1");

		char charEnumValue = Char.Parse(stringValue);
		var result = (Enum)Enum.ToObject(objectType, charEnumValue);
		result.EnsureEnumValueIsDefined(objectType);

		return result;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => objectType.IsEnum;

}
