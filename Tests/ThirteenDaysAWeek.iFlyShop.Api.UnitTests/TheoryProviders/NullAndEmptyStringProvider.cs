using System.Collections;
using System.Collections.Generic;

namespace ThirteenDaysAWeek.iFlyShop.Api.UnitTests.TheoryProviders
{
    public class NullAndEmptyStringProvider : IEnumerable<object[]>
    {
        private static readonly IEnumerable<object[]> _data = new List<object[]>
        {
            new []{ string.Empty },
            new []{ "\t" },
            new []{ "\r\n" },
            new []{ "\n" },
            new []{ (string)null }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}