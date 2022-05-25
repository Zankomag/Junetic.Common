using Junetic.Common.Abstractions;
using Junetic.Common.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Junetic.Common.Extensions; 

/// <summary></summary>
public static class ServiceCollectionExtensions {

	/// <summary>
	/// Adds, configures and validates options section from appsettings.Env.json file
	/// </summary>
	public static IServiceCollection AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration, string sectionName) where TOptions : class, ISettings {
		var configSection = configuration.GetSection(sectionName);
		services.Configure<TOptions>(configSection);
		services.AddOptionsValidator<TOptions>();
		return services;
	}

	/// <summary>
	/// Adds <see cref="OptionsValidator{TOptions}"/>
	/// </summary>
	public static IServiceCollection AddOptionsValidator<TOptions>(this IServiceCollection services) where TOptions : class, ISettings {
		services.AddSingleton<IValidateOptions<TOptions>, OptionsValidator<TOptions>>();
		return services;
	}

}