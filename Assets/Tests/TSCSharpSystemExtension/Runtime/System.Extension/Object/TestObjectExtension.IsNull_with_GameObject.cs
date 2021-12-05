using NUnit.Framework;
using UnityEngine;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestObjectExtension
    {
        public sealed class IsNull_with_GameObject
        {
            GameObject _target;

            [SetUp]
            public void SetUp()
            {
                _target = new GameObject("TestObjectExtension_Target");
            }

            [TearDown]
            public void TearDown()
            {
                Object.DestroyImmediate(_target);
            }

            [Test]
            public void IsNull_ReturnsFalse_IfTargetIsNotNull()
            {
                // when
                bool actual = _target.IsNull();

                // then
                Assert.False(actual);
            }

            [Test]
            public void IsNull_ReturnsTrue_IfTargetIsDestroyed()
            {
                // setup
                Object.DestroyImmediate(_target);

                // when
                bool actual = _target.IsNull();

                // then
                Assert.True(actual);
            }

            [Test]
            public void IsNull_ReturnsTrue_IfTargetIsNull()
            {
                // when
                _target = null;
                bool actual = _target.IsNull();

                // then
                Assert.True(actual);
            }
        }
    }
}
