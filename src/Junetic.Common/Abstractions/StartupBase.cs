using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Junetic.Common.Abstractions;

/// <summary>
/// Basic implementation of <see cref="IStartup"/> with injection of <see cref="IConfiguration"/>
/// </summary>
[PublicAPI]
public abstract class StartupBase : IStartup {

	/// <summary></summary>
	protected IConfiguration Configuration { get; }

	/// <summary></summary>
	/// <param name="configuration"></param>
	protected StartupBase(IConfiguration configuration) => Configuration = configuration;

	/// <inheritdoc />
	public abstract void ConfigureServices(IServiceCollection services);

}