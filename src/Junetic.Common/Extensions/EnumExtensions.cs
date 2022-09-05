using System.ComponentModel;

namespace Junetic.Common.Extensions; 

/// <summary></summary>
public static class EnumExtensions {

	//TODO Add unit tests
	
	/// <summary>
	/// Checks if passed enum value exists in enum. If not - throws an exception
	/// <para> Converts enum value to a char and then to a string.</para>
	/// <para> It's useful for enums which has value representation as a char. </para>
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException"></exception>
	public static string ValueToCharAsString(this Enum value) {
		if(value == null) throw new ArgumentNullException(nameof(value));
		value.EnsureEnumValueIsDefined(value.GetType());

		char charEnumValue = Convert.ToChar(value);
		return charEnumValue.ToString();
	}

	/// <summary>
	/// Throws an exception if provided enum value does not exist in provided enumType definition
	/// </summary>
	/// <param name="value"></param>
	/// <param name="enumType">If type is not a enum type or is not a type of <paramref name="value"/>'s enum type - exception will be thrown</param>
	/// <exception cref="InvalidEnumArgumentException"></exception>
	public static void EnsureEnumValueIsDefined(this Enum value, Type enumType) {
		if(!Enum.IsDefined(enumType, value)) {
			char valueChar = Convert.ToChar(value);

			// IsControl() check is made in case of unsafe to print char values such as (char)0 which we'll get from `default` keyword for enums
			throw new InvalidEnumArgumentException($"Value {(!Char.IsControl(valueChar) ? $"'{valueChar}'" : ((int)valueChar).ToString())} is not defined for {enumType} enum");
		}
	}

}
