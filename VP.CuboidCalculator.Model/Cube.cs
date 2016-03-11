using System;
using System.Linq;

namespace VP.CuboidCalculator.Model
{
    public class Cube
    {
        public Cube(uint width, uint height, uint length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        public uint Width { get; }
        public uint Height { get; }
        public uint Length { get; }

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
            return new Cube(uint.Parse(width), uint.Parse(height), uint.Parse(length));
        }
    }
}
