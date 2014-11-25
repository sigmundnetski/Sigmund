using Buddy.Common.Math;
using ClipperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.Collections.Generic.List<ClipperLib.IntPoint>;

namespace Omnibus.Dodge
{
    public class Polygon
    {
        public List<Vector3> Points = new List<Vector3>();

        public void Add(Vector3 point)
        {
            Points.Add(point);
        }

        public Path ToClipperPath()
        {
            var result = new Path(Points.Count);

            foreach (var point in Points)
            {
                result.Add(new IntPoint(point.X, point.Y));
            }

            return result;
        }

        public bool IsOutside(Vector3 point)
        {
            var p = new IntPoint(point.X, point.Y);
            return Clipper.PointInPolygon(p, ToClipperPath()) != 1;
        }

    }
}
