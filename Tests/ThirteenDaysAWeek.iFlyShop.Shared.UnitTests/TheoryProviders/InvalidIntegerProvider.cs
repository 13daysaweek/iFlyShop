using System.Collections;
using System.Collections.Generic;

namespace ThirteenDaysAWeek.iFlyShop.Shared.UnitTests.TheoryProviders
{
    public class InvalidIntegerProvider : IEnumerable<object[]>
    {
        private static readonly IEnumerable<object[]> _data = new List<object[]>
        {
            new []{ (object)0 },
            new []{ (object)-1 }
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
