using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using miRobotEditor.Classes;
using miRobotEditor.Controls.AngleConverter.Interfaces;

namespace miRobotEditor.Controls.AngleConverter.Classes
{
    [Localizable(false)]
    public sealed class Point3D : IGeometricElement3D, IFormattable
    {
        private readonly Vector3D _position;

        public Point3D()
        {
            _position = new Vector3D();
        }

        public Point3D(Point3D point)
        {
            _position = point._position;
        }

        public Point3D(Vector3D position)
        {
            _position = position;
        }

        public Point3D(double x, double y, double z)
        {
            _position = new Vector3D(x, y, z);
        }

        public double X
        {
            get { return _position[0]; }
            set { _position[0] = value; }
        }

        public double Y
        {
            get { return _position[1]; }
            set { _position[1] = value; }
        }

        public double Z
        {
            get { return _position[2]; }
            set { _position[2] = value; }
        }

        TransformationMatrix3D IGeometricElement3D.Position
        {
            get { return new TransformationMatrix3D(_position, RotationMatrix3D.Identity()); }
        }

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (format == null)
            {
                format = "F2";
            }
            if (!format.ToUpper().StartsWith("F"))
            {
                throw new FormatException("Invalid Format Specifier");
            }
            return string.Format("[{0}, {1}, {2}]", X.ToString(format), Y.ToString(format), Z.ToString(format));
        }

        private bool Equals(Point3D other)
        {
            return Equals(_position, other._position);
        }

        public override bool Equals(object obj)
        {
            return !ReferenceEquals(null, obj) &&
                   (ReferenceEquals(this, obj) || (obj is Point3D && Equals((Point3D) obj)));
        }

        public override int GetHashCode()
        {
            return (_position != null) ? _position.GetHashCode() : 0;
        }

        public static Point3D Centroid(Collection<Point3D> points)
        {
            var leastSquaresFit3D = new LeastSquaresFit3D();
            return leastSquaresFit3D.Centroid(points);
        }

        public static Point3D operator +(Point3D point, Vector3D vec)
        {
            return Add(point, vec);
        }

        public static Point3D Add(Point3D point, Vector3D vec)
        {
            return new Point3D
            {
                X = point.X + vec.X,
                Y = point.Y + vec.Y,
                Z = point.Z + vec.Z
            };
        }

        public static explicit operator Vector3D(Point3D point)
        {
            return new Vector3D(point._position);
        }

        public static Collection<Point3D> operator *(Collection<TransformationMatrix3D> transforms, Point3D point)
        {
            var collection = new Collection<Point3D>();
            foreach (var current in transforms)
            {
                collection.Add(current*point);
            }
            return collection;
        }

        public static Collection<Point3D> Multiply(Collection<TransformationMatrix3D> transforms, Point3D point)
        {
            var collection = new Collection<Point3D>();
            foreach (var current in transforms)
            {
                collection.Add(current*point);
            }
            return collection;
        }

        public static Point3D operator *(RotationMatrix3D mat, Point3D pt)
        {
            var vec = new Vector3D(pt.X, pt.Y, pt.Z);
            return new Point3D(new Vector3D(mat*vec));
        }

        public static Vector3D operator -(Point3D p1, Point3D p2)
        {
            return new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
        }

        public static Vector3D Subtract(Point3D p1, Point3D p2)
        {
            return new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
        }

        public static bool operator ==(Point3D p1, Point3D p2)
        {
            return p1 == p2;
        }

        public static bool Equals(Point3D p1, Point3D p2)
        {
            return p1 == p2;
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !(p1 == p2);
        }

        [Localizable(false)]
        public override string ToString()
        {
            return string.Format("[{0:F2}, {1:F2}, {2:F2}]", X, Y, Z);
        }
    }
}