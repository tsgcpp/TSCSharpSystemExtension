using System.Collections.Generic;
using NUnit.Framework;
using Tests.SampleType;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestReadOnlyListExtensions
    {
        public sealed class Contains_with_val
        {
            IReadOnlyList<EquatableData> _target;
            IReadOnlyList<EquatableData> _targetWithoutFoundItem;
            IReadOnlyList<EquatableData> _targetEmpty;

            EquatableData _foundItem;

            [SetUp]
            public void SetUp()
            {
                _foundItem = new EquatableData { value = 222 };

                _target = new List<EquatableData>
                {
                    new EquatableData { value = 111 },
                    _foundItem,
                    new EquatableData { value = 333 },
                };

                _targetWithoutFoundItem = new List<EquatableData>
                {
                    new EquatableData { value = 111 },
                    new EquatableData { value = 123 },
                    new EquatableData { value = 333 },
                };

                _targetEmpty = new List<EquatableData>();
            }

            [Test]
            public void ReturnsTrueIfListHasFoundItem()
            {
                Assert.True(_target.Contains(_foundItem));
            }

            [Test]
            public void ReturnsFalseIfListDoesNotHaveFoundItem()
            {
                Assert.False(_targetWithoutFoundItem.Contains(_foundItem));
            }

            [Test]
            public void ReturnsFalseIfListIsEmpty()
            {
                Assert.False(_targetEmpty.Contains(_foundItem));
            }
        }
    }
}
