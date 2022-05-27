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
		if(services is null) throw new ArgumentNullException(nameof(services));
		if(configuration is null) throw new ArgumentNullException(nameof(configuration));
		if(String.IsNullOrWhiteSpace(sectionName)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(sectionName));

		//todo add also Action<TOptions> options to configure options during initialization that OVERRIDES appsettings.
		var configSection = configuration.GetSection(sectionName);
		services.Configure<TOptions>(configSection);
		services.AddOptionsValidator<TOptions>();
		return services;
	}

	/// <summary>
	/// Adds <see cref="OptionsValidator{TOptions}"/>
	/// </summary>
	public static IServiceCollection AddOptionsValidator<TOptions>(this IServiceCollection services) where TOptions : class, ISettings {
		if(services is null) throw new ArgumentNullException(nameof(services));
		
		services.AddSingleton<IValidateOptions<TOptions>, OptionsValidator<TOptions>>();
		return services;
	}

}