using NUnit.Framework;
using System.Extension;

namespace Tests.System.Extension
{
    public sealed partial class TestObjectExtension
    {
        public sealed class IsNull_with_Object
        {
            object _target;

            [SetUp]
            public void SetUp()
            {
                _target = new object();
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
