using Buddy.Common.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Dodge
{
    public class Rectangle
    {
        public Vector3 Direction;
        public Vector3 Perpendicular;
        public Vector3 REnd;
        public Vector3 RStart;
        public float Width;

        public Rectangle(Vector3 start, Vector3 end, float width)
        {
            RStart = start;
            REnd = end;
            Width = width;
            Direction = (end - start);
            Direction.Normalize();

            Perpendicular = Direction.Perpendicular();
        }

        public Polygon ToPolygon(int offset = 0, float overrideWidth = -1)
        {
            var result = new Polygon();

            result.Add(
                RStart + (overrideWidth > 0 ? overrideWidth : Width + offset) * Perpendicular - offset * Direction);
            result.Add(
                RStart - (overrideWidth > 0 ? overrideWidth : Width + offset) * Perpendicular - offset * Direction);
            result.Add(
                REnd - (overrideWidth > 0 ? overrideWidth : Width + offset) * Perpendicular + offset * Direction);
            result.Add(
                REnd + (overrideWidth > 0 ? overrideWidth : Width + offset) * Perpendicular + offset * Direction);

            return result;
        }
    }
}
