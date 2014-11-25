using Buddy.Common.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Dodge
{
    public class Sector
    {
        private const int CircleLineSegmentN = 22;
        public float Angle;
        public Vector3 Center;
        public Vector3 Direction;
        public float Radius;

        public Sector(Vector3 center, Vector3 direction, float angle, float radius)
        {
            Center = center;
            Direction = direction;
            Angle = angle;
            Radius = radius;
        }

        public Polygon ToPolygon(int offset = 0)
        {
            var result = new Polygon();
            var outRadius = (Radius + offset) / (float)Math.Cos(2 * Math.PI / CircleLineSegmentN);

            result.Add(Center);
            var Side1 = Direction.Rotated(-Angle * 0.5f);

            for (var i = 0; i <= CircleLineSegmentN; i++)
            {
                var cDirection = Side1.Rotated(i * Angle / CircleLineSegmentN);
                cDirection.Normalize();

                result.Add(new Vector3(Center.X + outRadius * cDirection.X, Center.Y + outRadius * cDirection.Y, Center.Z));
            }

            return result;
        }
    }
}
