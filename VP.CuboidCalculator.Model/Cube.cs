using System;
using System.Linq;

namespace VP.CuboidCalculator.Model
{
    public class Cube
    {
        public Cube(int width, int height, int length)
        {
            ValidateNumbers(Width, Height, Length);

            Width = width;
            Height = height;
            Length = length;
        }

        private void ValidateNumbers(params int[] numbers)
        {
            if (numbers.Any(number => number < 0)) throw new ArgumentException("Cube can only have positive dimensions");
        }

        public int Width { get; }
        public int Height { get; }
        public int Length { get; }

        public decimal GetArea()
        {
            return (Width*Height + Width*Length + Height*Length) * 2;
        }

        public decimal GetVolume()
        {
            return Width * Height * Length;
        }

        public static Cube FromStrings(string width, string height, string length)
        {
            return new Cube(int.Parse(width), int.Parse(height), int.Parse(length));
        }
    }
}
