using Microsoft.Extensions.DependencyInjection;

namespace Junetic.Common.Abstractions; 

/// <summary>
/// Interface for Startup classes for hosted applications
/// </summary>
public interface IStartup {

	/// <summary>
	/// 
	/// </summary>
	/// <param name="services"></param>
	void ConfigureServices(IServiceCollection services);
	
}