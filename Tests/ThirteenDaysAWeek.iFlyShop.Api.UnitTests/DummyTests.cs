using FluentAssertions;
using Xunit;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests
{
    public class DummyTests
    {
        [Fact]
        public void True_Should_Be_True_Obviously()
        {
            true.Should()
                .BeTrue();
        }
    }
}
