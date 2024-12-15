using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpace
{
    public interface IRotatingObject
    {
        Angle AnglePos { get; set; }
        Angle RotateVelocity { get; }
        void Rotate();
    }

    public class RotateCommand : ICommand
    {
        private readonly IRotatingObject _rotatingObject;

        public RotateCommand(IRotatingObject rotatingObject)
        {
            _rotatingObject = rotatingObject;
        }

        public void Execute()
        {
            if (_rotatingObject == null)
                throw new InvalidOperationException("Rotating object is null");

            if (_rotatingObject.RotateVelocity == null)
                throw new InvalidOperationException("Rotate velocity is not defined");

            if (_rotatingObject.AnglePos == null)
                throw new InvalidOperationException("Angle position is not defined");

            _rotatingObject.AnglePos = _rotatingObject.AnglePos + _rotatingObject.RotateVelocity;
        }
    }
}
