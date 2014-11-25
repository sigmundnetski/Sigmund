using Buddy.Common.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Dodge
{
    public class Circle
    {
        private const int CircleLineSegmentN = 22;
        public Vector3 Center;
        public float Radius;

        public Circle(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        public Polygon ToPolygon(int offset = 0, float overrideWidth = -1)
        {
            var result = new Polygon();
            var outRadius = (overrideWidth > 0
                ? overrideWidth
                : (offset + Radius) / (float)Math.Cos(2 * Math.PI / CircleLineSegmentN));

            for (var i = 1; i <= CircleLineSegmentN; i++)
            {
                var angle = i * 2 * Math.PI / CircleLineSegmentN;
                var point = new Vector3(Center.X + outRadius * (float)Math.Cos(angle), Center.Y + outRadius * (float)Math.Sin(angle), Center.Z);
                result.Add(point);
            }

            return result;
        }
    }
}
