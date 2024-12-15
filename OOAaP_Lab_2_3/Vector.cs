using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Vector
{
    public int[] Coordinates { get; }

    public Vector(params int[] coordinates)
    {
        if (coordinates == null || coordinates.Length == 0)
        {
            throw new ArgumentException(nameof(coordinates), "Вектор не может быть пустым.");
        }

        Coordinates = coordinates;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        if (v1.Coordinates.Length != v2.Coordinates.Length)
            throw new ArgumentException("Векторы должны иметь одинаковую размерность");

        return new Vector(v1.Coordinates.Zip(v2.Coordinates, (a, b) => a + b).ToArray());
    }

    public override bool Equals(object? obj)
    {
        if (obj is Vector)
        {
            return Coordinates.SequenceEqual((obj as Vector)!.Coordinates);
        }
        else
        {
            return false;
        }
    }

    public static bool operator ==(Vector v1, Vector v2)
    {
        if (v1 is null && v2 is null) return true;
        if (v1 is null || v2 is null) return false;
        return v1.Equals(v2);
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    public override int GetHashCode()
    {
        return Coordinates.GetHashCode();
    }

    static void Main()
    {
        Console.WriteLine("Hellow World!");
    }

}

