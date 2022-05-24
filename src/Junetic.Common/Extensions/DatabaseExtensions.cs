﻿namespace Junetic.Common.Extensions; 

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
	public static int PageCount(this int itemCount, int pageSize) => (int)Math.Ceiling(itemCount / (double)pageSize);

}