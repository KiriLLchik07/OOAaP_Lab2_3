using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSpace;

namespace XUnitTest
{
    public class RotateTests
    {
        [Fact]
        public void Rotate_CommandExecutes_CorrectAngleChange()
        {
            var mockRotatingObject = new Mock<IRotatingObject>();
            mockRotatingObject.SetupGet(ro => ro.AnglePos).Returns(new Angle(45));
            mockRotatingObject.SetupGet(ro => ro.RotateVelocity).Returns(new Angle(45));
            mockRotatingObject.SetupSet(ro => ro.AnglePos = It.IsAny<Angle>()).Verifiable();

            var command = new RotateCommand(mockRotatingObject.Object);

            command.Execute();

            mockRotatingObject.VerifySet(ro => ro.AnglePos = new Angle(90), Times.Once);
        }

        [Fact]
        public void Rotate_InvalidAnglePosition_ThrowsException()
        {
            var mockRotatingObject = new Mock<IRotatingObject>();
            mockRotatingObject.SetupGet(ro => ro.AnglePos).Returns((Angle)null);

            var command = new RotateCommand(mockRotatingObject.Object);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }

        [Fact]
        public void Rotate_InvalidRotateVelocity_ThrowsException()
        {
            var mockRotatingObject = new Mock<IRotatingObject>();
            mockRotatingObject.SetupGet(ro => ro.RotateVelocity).Returns((Angle)null);

            var command = new RotateCommand(mockRotatingObject.Object);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }

        [Fact]
        public void Rotate_InvalidRotatingObject_ThrowsException()
        {
            IRotatingObject rotatingObject = null;

            var command = new RotateCommand(rotatingObject);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }

        [Fact]
        public void Rotate_UnableToChangeAnglePosition_ThrowsException()
        {
            var mockRotatingObject = new Mock<IRotatingObject>();
            mockRotatingObject.SetupGet(ro => ro.AnglePos).Returns(new Angle(45));
            mockRotatingObject.SetupGet(ro => ro.RotateVelocity).Returns(new Angle(45));
            mockRotatingObject.SetupSet(ro => ro.AnglePos = It.IsAny<Angle>()).Throws(new InvalidOperationException());

            var command = new RotateCommand(mockRotatingObject.Object);

            Assert.Throws<InvalidOperationException>(() => command.Execute());
        }
    }
}
