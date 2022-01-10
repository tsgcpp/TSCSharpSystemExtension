using System.Collections.Generic;
using NUnit.Framework;
using System.Extension;

namespace Tests.System.Extension
{
    public partial class TestListExtensions
    {
        public class Remove
        {
            List<object> _target;

            [SetUp]
            public void SetUp()
            {
                _comparer = EqualityComparer<object>.Default;

                _item1 = new object();
                _item2 = new object();
                _item3 = new object();

                _itemEx1 = new object();

                _target = new List<object>
                {
                    _item1,
                    _item2,
                    _item3,
                };
            }

            [Test]
            public void Remove_ReturnsTrueIfTargetExists_First()
            {
                // when
                bool actual = _target.Remove(_item1, comparer: _comparer);

                // then
                Assert.True(actual);
                Assert.AreEqual(2, _target.Count);
                Assert.AreEqual(_item2, _target[0]);
                Assert.AreEqual(_item3, _target[1]);
            }

            [Test]
            public void Remove_ReturnsTrueIfTargetExists_Center()
            {
                // when
                bool actual = _target.Remove(_item2, comparer: _comparer);

                // then
                Assert.True(actual);
                Assert.AreEqual(2, _target.Count);
                Assert.AreEqual(_item1, _target[0]);
                Assert.AreEqual(_item3, _target[1]);
            }

            [Test]
            public void Remove_ReturnsTrueIfTargetExists_Last()
            {
                // when
                bool actual = _target.Remove(_item3, comparer: _comparer);

                // then
                Assert.True(actual);
                Assert.AreEqual(2, _target.Count);
                Assert.AreEqual(_item1, _target[0]);
                Assert.AreEqual(_item2, _target[1]);
            }

            [Test]
            public void Remove_ReturnsFalseIfTargetDoesNotExists()
            {
                // when
                bool actual = _target.Remove(_itemEx1, comparer: _comparer);

                // then
                Assert.False(actual);
                Assert.AreEqual(3, _target.Count);
                Assert.AreEqual(_item1, _target[0]);
                Assert.AreEqual(_item2, _target[1]);
                Assert.AreEqual(_item3, _target[2]);
            }

            [Test]
            public void Remove_ReturnsFalseIfListIsEmpty()
            {
                // setup
                _target.Clear();
                Assert.AreEqual(0, _target.Count);

                // when
                bool actual = _target.Remove(_item2, comparer: _comparer);

                // then
                Assert.False(actual);
                Assert.AreEqual(0, _target.Count);
            }

            IEqualityComparer<object> _comparer;

            object _item1;
            object _item2;
            object _item3;

            object _itemEx1;
        }
    }
}
