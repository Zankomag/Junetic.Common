using System.Diagnostics;
using JetBrains.Annotations;
using Junetic.Common.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IStartup = Junetic.Common.Abstractions.IStartup;

namespace Junetic.Common.Extensions; 

/// <summary>
///     Extensions to emulate a typical "Startup.cs" pattern for <see cref="IHostBuilder" />
/// </summary>
[PublicAPI]
public static class HostBuilderExtensions {

	/// <summary>
	///     Specify the startup type to be used by the host.
	/// </summary>
	/// <typeparam name="TStartup">
	///     The type containing a constructor with
	///     an <see cref="IConfiguration" /> parameter. The implementation should contain a public
	///     method named ConfigureServices with <see cref="IServiceCollection" /> parameter.
	/// </typeparam>
	/// <param name="hostBuilder">The <see cref="IHostBuilder" /> to initialize with TStartup.</param>
	/// <returns>The same instance of the <see cref="IHostBuilder" /> for chaining.</returns>
	public static IHostBuilder UseStartup<TStartup>(this IHostBuilder hostBuilder) where TStartup : IStartup {
		hostBuilder.ConfigureServices((context, serviceCollection) => {
			IStartup startup = (TStartup)Activator.CreateInstance(typeof(TStartup), context.Configuration)!;
			Debug.Assert(startup != null, nameof(startup) + " is null");
			startup.ConfigureServices(serviceCollection);
		});
			
		return hostBuilder;
	}

	/// <summary>
	/// Sets Hosting Environment
	/// Adds config from appsettings.json and appsettings.{{EnvironmentName}}.json files
	/// Loads User Secrets if Development
	/// </summary>
	/// <param name="hostBuilder"></param>
	/// <typeparam name="TUserSecretsAssembly">Type from assembly where user secrets are stored in (which are used for Development environment only.
	/// If this method is called from project which is service project, as usually happens, Program class can be passed here</typeparam>
	/// <returns></returns>
	public static IHostBuilder AddConfiguration<TUserSecretsAssembly>(this IHostBuilder hostBuilder) where TUserSecretsAssembly : class {
		hostBuilder.ConfigureAppConfiguration((hostingContext, configurationBuilder) => {
			hostingContext.HostingEnvironment.EnvironmentName = EnvironmentWrapper.GetEnvironmentName();
				
			configurationBuilder.AddJsonFile("appsettings.json", false)
				.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", false);

			if(hostingContext.HostingEnvironment.IsDevelopment() && !String.IsNullOrEmpty(hostingContext.HostingEnvironment.ApplicationName)) {
				configurationBuilder.AddUserSecrets<TUserSecretsAssembly>();
			}
			
			configurationBuilder.AddEnvironmentVariables();
		});
		return hostBuilder;
	}
		

}