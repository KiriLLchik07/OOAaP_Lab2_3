using System.Numerics;

namespace VectorTest
{
    public class VectorTests
    {
        [Fact]
        public void VectorAddition_SameDimension_VectorsSumCorrectly()
        {
            var v1 = new Vector(1, -1, 2);
            var v2 = new Vector(-1, 1, -2);

            var result = v1 + v2;

            Assert.Equal(new Vector(0, 0, 0), result);
        }

        [Fact]
        public void VectorAddition_DifferentDimensions_ThrowsArgumentException()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 2);

            Assert.Throws<ArgumentException>(() => v1 + v2);
        }

        [Fact]
        public void VectorAddition_DifferentDimensions_Reversed_ThrowsArgumentException()
        {
            var v1 = new Vector(1, 2);
            var v2 = new Vector(1, 2, 3);

            Assert.Throws<ArgumentException>(() => v1 + v2);
        }

        [Fact]
        public void VectorEquals_SameCoordinates_DifferentObjects_ReturnsTrue()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 2, 3);

            Assert.True(v1.Equals(v2));
        }

        [Fact]
        public void VectorEquals_SameCoordinates_DifferentObjects_OperatorEquals_ReturnsTrue()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(1, 2, 3);

            Assert.True(v1 == v2);
        }

        [Fact]
        public void VectorEquals_DifferentCoordinates_DifferentObjects_ReturnsFalse()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(4, 5, 6);

            Assert.False(v1.Equals(v2));
        }

        [Fact]
        public void VectorNotEquals_DifferentCoordinates_DifferentObjects_OperatorNotEquals_ReturnsTrue()
        {
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(4, 5, 6);

            Assert.True(v1 != v2);
        }

        [Fact]
        public void VectorGetHashCode_HashCodeExists()
        {
            var v = new Vector(1, 2, 3);

            Assert.NotEqual(0, v.GetHashCode());
        }
    }
}