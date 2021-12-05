using NUnit.Framework;
using UnityEngine;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestObjectExtension
    {
        public sealed class IsNull_with_Component
        {
            Component _target;
            GameObject _targetGo;

            [SetUp]
            public void SetUp()
            {
                _targetGo = new GameObject("TestObjectExtension_Target_IsNull_with_Component");
                _target = _targetGo.AddComponent<MeshRenderer>();
            }

            [TearDown]
            public void TearDown()
            {
                Object.DestroyImmediate(_targetGo);
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
            public void IsNull_ReturnsTrue_IfGameObjectIsDestroyed()
            {
                // setup
                Object.DestroyImmediate(_target.gameObject);

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
