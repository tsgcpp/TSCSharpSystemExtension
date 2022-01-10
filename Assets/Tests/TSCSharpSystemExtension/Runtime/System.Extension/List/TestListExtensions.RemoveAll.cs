using System.Collections.Generic;
using NUnit.Framework;
using System.Extension;

namespace Tests.System.Extension
{
    public partial class TestListExtensions
    {
        public class RemoveAll
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
            public void RemoveAll_ReturnsRemovedItemsCountIfTargetExists_OnlyCenter()
            {
                // when
                int actual = _target.RemoveAll(_item2, comparer: _comparer);

                // then
                Assert.AreEqual(1, actual);
                Assert.AreEqual(2, _target.Count);
                Assert.AreEqual(_item1, _target[0]);
                Assert.AreEqual(_item3, _target[1]);
            }

            [Test]
            public void RemoveAll_ReturnsRemovedItemsCountIfTargetExists_ExceptCenter()
            {
                // setup
                _target = new List<object>
                {
                    _item2,
                    _item1,
                    _item2,
                };

                // when
                int actual = _target.RemoveAll(_item2, comparer: _comparer);

                // then
                Assert.AreEqual(2, actual);
                Assert.AreEqual(1, _target.Count);
                Assert.AreEqual(_item1, _target[0]);
            }

            [Test]
            public void RemoveAll_ReturnsRemovedItemsCountIfTargetExists_All()
            {
                // setup
                _target = new List<object>
                {
                    _item2,
                    _item2,
                    _item2,
                };

                // when
                int actual = _target.RemoveAll(_item2, comparer: _comparer);

                // then
                Assert.AreEqual(3, actual);
                Assert.AreEqual(0, _target.Count);
            }

            [Test]
            public void RemoveAll_ReturnsFalseIfTargetDoesNotExist()
            {
                // when
                int actual = _target.RemoveAll(_itemEx1, comparer: _comparer);

                // then
                Assert.AreEqual(0, actual);
                Assert.AreEqual(3, _target.Count);
                Assert.AreEqual(_item1, _target[0]);
                Assert.AreEqual(_item2, _target[1]);
                Assert.AreEqual(_item3, _target[2]);
            }

            [Test]
            public void RemoveAll_ReturnsFalseIfListIsEmpty()
            {
                // setup
                _target.Clear();
                Assert.AreEqual(0, _target.Count);

                // when
                int actual = _target.RemoveAll(_item2, comparer: _comparer);

                // then
                Assert.AreEqual(0, actual);
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
