using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSpace;

namespace XUnitTest
{
    public class AngleTests
    {
        [Fact]
        public void TestAngleAddition()
        {
            Angle angle1 = new Angle(5);
            Angle angle2 = new Angle(7);
            Angle result = angle1 + angle2;
            Assert.Equal(4, result.Numerator);
        }

        [Fact]
        public void TestAngleEqualityEquals()
        {
            Angle angle1 = new Angle(15);
            Angle angle2 = new Angle(23);
            Assert.True(angle1.Equals(angle2));
        }

        [Fact]
        public void TestAngleEqualityOperator()
        {
            Angle angle1 = new Angle(15);
            Angle angle2 = new Angle(23);
            Assert.True(angle1 == angle2);
        }

        [Fact]
        public void TestAngleInequalityEquals()
        {
            Angle angle1 = new Angle(1);
            Angle angle2 = new Angle(2);
            Assert.False(angle1.Equals(angle2));
        }

        [Fact]
        public void TestAngleInequalityOperator()
        {
            Angle angle1 = new Angle(1);
            Angle angle2 = new Angle(2);
            Assert.True(angle1 != angle2);
        }

        [Fact]
        public void TestHashCode()
        {
            Angle angle = new Angle(5);
            int hashCode = angle.GetHashCode();
            Assert.NotEqual(0, hashCode);
        }

        [Fact]
        public void TestSinAndCos()
        {
            Angle angle = new Angle(4);
            double sinValue = angle.Sin();
            double cosValue = angle.Cos();

            double expectedSin = Math.Sin(4 * 2 * Math.PI / Angle.Denominator);
            double expectedCos = Math.Cos(4 * 2 * Math.PI / Angle.Denominator);
            Assert.True(Math.Abs(sinValue - expectedSin) < 0.001);
            Assert.True(Math.Abs(cosValue - expectedCos) < 0.001);
        }
    }
}
