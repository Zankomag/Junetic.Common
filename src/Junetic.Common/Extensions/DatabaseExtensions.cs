namespace Junetic.Common.Extensions; 

//todo add unit tests
/// <summary>
/// Extensions for working with database queries
/// </summary>
public static class DatabaseExtensions {

	/// <summary>
	/// Calculates how many item pages should be for items per pageSize 
	/// </summary>
	/// <param name="itemCount"></param>
	/// <param name="pageSize"></param>
	/// <returns></returns>
	public static long PageCount(this long itemCount, int pageSize) {
		if(itemCount <= 0) throw new ArgumentException("parameter must be greater than zero", nameof(itemCount));
		if(pageSize <= 0) throw new ArgumentException("parameter must be greater than zero", nameof(pageSize));
		return (long)Math.Ceiling(itemCount / (double)pageSize);
	}
	
}