using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSpace
{
    public class Angle
    {
        public static int Denominator = 8;

        public int Numerator { get; private set; }

        public Angle(int numerator)
        {
            Numerator = NormalizeNumerator(numerator);
        }

        private int NormalizeNumerator(int numerator)
        {
            return (numerator % Denominator + Denominator) % Denominator;
        }

        public static Angle operator +(Angle a, Angle b)
        {
            int newNumerator = (a.Numerator + b.Numerator) % Denominator;
            return new Angle(newNumerator);
        }

        public override bool Equals(object obj)
        {
            if (obj is Angle other)
            {
                return Numerator == other.Numerator;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode();
        }

        public static bool operator ==(Angle a, Angle b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.Numerator == b.Numerator;
        }

        public static bool operator !=(Angle a, Angle b)
        {
            return !(a == b);
        }

        public double Sin()
        {
            double angleInRadians = (Numerator * 2 * Math.PI) / Denominator;
            return Math.Sin(angleInRadians);
        }

        public double Cos()
        {
            double angleInRadians = (Numerator * 2 * Math.PI) / Denominator;
            return Math.Cos(angleInRadians);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
