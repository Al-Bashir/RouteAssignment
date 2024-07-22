using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_OOP05.Point
{
    internal class Point3D : IComparable ,ICloneable 
    {
        public int FirstPoint { get; set; }
        public int SecondPoint { get; set; }
        public int ThirdPoint { get; set; }

        public Point3D(int firstPoint, int secondPoint, int thirdPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
        }

        public override string ToString()
        {
            return $"Point Coordinates: ({FirstPoint}, {SecondPoint}, {ThirdPoint})";
        }

        public int CompareTo(object? obj)
        {
            Point3D PassedPoint3D = (Point3D)obj;
            if (this.FirstPoint.CompareTo(PassedPoint3D?.FirstPoint) == 0)
            {
                return this.SecondPoint.CompareTo(PassedPoint3D?.SecondPoint);
            }
            return this.FirstPoint.CompareTo(PassedPoint3D?.FirstPoint);
        }

        public object Clone()
        {
            return new Point3D(
                    FirstPoint = FirstPoint, 
                    SecondPoint = SecondPoint, 
                    ThirdPoint = ThirdPoint
                );
        }

    }
}
