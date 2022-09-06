namespace Junetic.Common.Utilities;

/// <summary>
/// Helps determining name of environment application is running in
/// </summary>
public static class EnvironmentWrapper {

	/// <summary>
	/// Backup name of environment variable which indicates environment application is running in
	/// <para>Is overriden by DOTNET_ENVIRONMENT and ASPNETCORE_ENVIRONMENT</para>
	/// </summary>
	public const string BackupEnvironmentName = "ENVIRONMENT_NAME";

	/// <summary>
	/// Name of Development environment
	/// </summary>
	public const string Development = nameof(Development);

	/// <summary>
	/// Indicates whether current environment is <see cref="Development"/>
	/// </summary>
	public static bool IsDevelopment => GetEnvironmentName() == Development;

	/// <summary>
	/// Gets environment name which indicates environment application is running in.
	/// If no Environment name variable found, returns <see cref="Development"/>
	/// </summary>
	/// <returns></returns>
	public static string GetEnvironmentName() 
		=> Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
			?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") 
			?? Environment.GetEnvironmentVariable(BackupEnvironmentName) 
			?? Development; 

}