// ReSharper disable UnusedType.Global
namespace Junetic.Common.Abstractions;

/// <summary>
/// Used for configuration class for usage with Options pattern,
/// getting configuration from appsettings.json files
/// </summary>
public interface ISettings {

	/// <summary>
	/// The name of configuration section in appsettings.json file. If you think it matches settings class name - 
	/// use nameof(OptionsClass) for section name
	/// </summary>
	abstract static string SectionName { get; }

}