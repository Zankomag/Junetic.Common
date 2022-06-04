namespace Junetic.Common.Utilities;

public static class EnvironmentWrapper {

	/// <summary>
	/// name of environment variable which indicates environment application is running in
	/// </summary>
	public const string EnvironmentName = "ENVIRONMENT_NAME";

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
	/// If no <see cref="EnvironmentName"/> found, returns <see cref="Development"/>
	/// </summary>
	/// <returns></returns>
	public static string GetEnvironmentName() => Environment.GetEnvironmentVariable(EnvironmentName) ?? Development;

}