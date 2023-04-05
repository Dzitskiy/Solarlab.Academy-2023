using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Board.Tests
{
    public class CategoryIdTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() =>
            CategoryListFixture.Ids.Select(x => new object[] { x }).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}