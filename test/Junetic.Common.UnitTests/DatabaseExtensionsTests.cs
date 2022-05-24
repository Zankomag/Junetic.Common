using Junetic.Common.Extensions;

namespace Jumetic.Common.UnitTests;

public class DatabaseExtensionsTests {

	[Theory]
	[InlineData(15, 3, 5)]
	[InlineData(16, 3, 6)]
	[InlineData(17, 3, 6)]
	[InlineData(18, 3, 6)]
	[InlineData(19, 3, 7)]
	[InlineData(5, 4, 2)]
	[InlineData(5, 5, 1)]
	[InlineData(3, 3, 1)]
	public void PageCount_Succeeds(long itemCount, int pageSize, long expected) {
		var result = itemCount.PageCount(pageSize);
		Assert.Equal(expected, result);
	}

	[Theory]
	[InlineData(15, -3)]
	[InlineData(-15, 3)]
	[InlineData(-15, -3)]
	[InlineData(0, 3)]
	[InlineData(3, 0)]
	public void PageCount_Throws_WhenNegativeOrZeroInput(long itemCount, int pageSize) => Assert.Throws<ArgumentException>(() => itemCount.PageCount(pageSize));
	

}