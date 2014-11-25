using Buddy.Common;
using Buddy.Common.Math;
using Buddy.Wildstar.BotCommon;
using Buddy.Wildstar.Game;
using Buddy.Wildstar.Game.Actors;
using ClipperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.Collections.Generic.List<ClipperLib.IntPoint>;
using Paths = System.Collections.Generic.List<System.Collections.Generic.List<ClipperLib.IntPoint>>;

namespace Omnibus.Dodge
{
    public static class Evading
    {
        public static bool IsEvading { get; set; }

        public static Paths ClipPolygons(List<Polygon> polygons)
        {
            var subj = new Paths(polygons.Count);
            var clip = new Paths(polygons.Count);

            foreach (var polygon in polygons)
            {
                subj.Add(polygon.ToClipperPath());
                clip.Add(polygon.ToClipperPath());
            }

            var solution = new Paths();
            var c = new Clipper();
            c.AddPaths(subj, PolyType.ptSubject, true);
            c.AddPaths(clip, PolyType.ptClip, true);
            c.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftEvenOdd);

            return solution;
        }

        public static List<Polygon> ToPolygons(this Paths v)
        {
            var result = new List<Polygon>();

            foreach (var path in v)
            {
                result.Add(path.ToPolygon());
            }

            return result;
        }

        public static Polygon ToPolygon(this Path v)
        {
            var polygon = new Polygon();
            foreach (var point in v)
            {
				polygon.Add(new Vector3(point.X, point.Y, GameManager.ControlledUnit.Position.Z));
            }
            return polygon;
        }

        public static bool IsInDanger(this Vector3 point)
        {
            foreach (var telegraph in GameManager.Telegraphs.Where(t => t.IsInProgress))
            {
                if (telegraph.Disposition != Disposition.Hostile)
                    continue; 

                if (telegraph.Contains(point))
                    return false;
            }

            return true; 
        }

        public static List<Vector3> GetSafePoints(int speed = -1, int delay = 0)
        {
            var output = new List<Vector3>(); 
            var polygons = new List<Polygon>();
			var myPosition = GameManager.ControlledUnit.Position;

            foreach (var telegraph in GameManager.Telegraphs.Where(t => t.IsInProgress && t.CasterGuid != GameManager.LocalPlayer.Guid))
            {
                if (telegraph.Disposition != Disposition.Hostile)
                    continue; 

                Vector3 extents;
			    float minRange, maxRange, rotations;
			    telegraph.RetrieveShapeParams(out extents, out minRange, out maxRange, out rotations);

                var start = telegraph.Position;
                var forward = telegraph.Forward; 
                var rotated = forward.Rotated(Geometry.DegreeToRadian(telegraph.RotationDegrees));
                var end = start + rotated * maxRange;

                //Omnibus.Logger.Debug(string.Format("Rotations: {0}, MinRange: {1}, MaxRange: {2}, Extents: {3}", rotations, minRange, maxRange, extents));
                //Omnibus.Logger.Debug("Transformed " + telegraph.Position + " into " + start + " [Mag: " + start.Magnitude() + "]");
                //Omnibus.Logger.Debug("Calculated end: " + end);

                switch (telegraph.Shape)
                {
                    case TelegraphShape.Rectangle:
                    case TelegraphShape.Line:
                        polygons.Add(new Rectangle(start, end, 10).ToPolygon()); 
                        break;
                    case TelegraphShape.Sphere:
                        polygons.Add(new Circle(start, maxRange).ToPolygon());
                        break;
                    case TelegraphShape.CircleSector:
                        polygons.Add(new Sector(start, forward, telegraph.RotationDegrees, maxRange).ToPolygon());
                        break;
                }
            }

            var area = ClipPolygons(polygons).ToPolygons();

            foreach (var polygon in polygons)
            {
                for (int i = 0; i <= polygon.Points.Count - 1; i++)
                {
                    var sideStart = polygon.Points[i];
                    var sideEnd = polygon.Points[(i == polygon.Points.Count - 1) ? 0 : i + 1];

                    var candidate = myPosition.ProjectOn(sideStart, sideEnd).SegmentPoint;
                    var distance = Vector3.DistanceSquared(candidate, myPosition);

                    if (distance < 10) 
                    {
                        var distanceToSide = Vector3.DistanceSquared(sideStart, sideEnd);
                        var direction = sideEnd - sideStart;
                        direction.Normalize();

                        var start = (distance < 10 && distanceToSide > 0) ? 7 : 0;

                        for (int _i = -start; _i <= start; _i++)
                        {
                            var newCandidate = candidate + _i * 0 * direction;

							if (IsSafe(GameManager.ControlledUnit.Position, newCandidate))
                            {
                                Omnibus.Logger.Debug("Found candidate: " + newCandidate);
                                output.Add(newCandidate); 
                            }
                        }
                    }
                }
            }

            return output; 
        }

        public static bool IsSafe(Vector3 start, Vector3 end)
        {
            return !GameManager.CurrentWorld.Intersect(start, end); 
        }
    }
}
