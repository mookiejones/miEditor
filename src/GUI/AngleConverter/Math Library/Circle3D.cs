using System.ComponentModel;

namespace ISTUK.MathLibrary
{
    using System;
    using System.Collections.ObjectModel;

    [Localizable(false)]
    public class Circle3D : IGeometricElement3D
    {
        

        public Circle3D()
        {
            Origin = new Point3D();
            Normal = new Vector3D();
            Radius = 0.0;
        }

        public Circle3D(Circle3D circle)
        {
            Origin = circle.Origin;
            Normal = circle.Normal;
            Radius = circle.Radius;
        }

        public Circle3D(Point3D origin, Vector3D normal, double radius)
        {
            Origin = origin;
            Normal = normal;
            Radius = radius;
        }

        public static Circle3D FitToPoints(Collection<Point3D> points)
        {
            var fitd = new LeastSquaresFit3D();
            return fitd.FitCircleToPoints(points);
        }

        public static Circle3D FitToPoints2(Collection<Point3D> points)
        {
            var fitd = new LeastSquaresFit3D();
            return fitd.FitCircleToPoints2(points);
        }

        public override string ToString()
        {
            return ToString(null, null);
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("Circle3D: Centre {0}, Normal {1}, Radius {2:F2}", Origin, Normal, Radius);
        }

        public Vector3D Normal { get; set; }

        public Point3D Origin { get; set; }
        public TransformationMatrix3D Position
        {
            get
            {
                return new TransformationMatrix3D((Vector3D)Origin, RotationMatrix3D.Identity());
            }
        }

        public double Radius { get; set; }
    }
}

