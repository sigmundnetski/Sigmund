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
    public static class Geometry
    {
        /// <summary>
        ///     Iteration for Evade point query
        /// </summary>
        private const int CircleLineSegmentN = 22;
        
        /// <summary>
        ///     Downgrade Vector3 to Vector2
        /// </summary>
        public static Vector2 To2D(this Vector3 v) 
        {
            return new Vector2(v.X, v.Y); 
        }

        /// <summary>
        ///     Return if the Vector is empty, only a temporary solution. 
        /// </summary>
        public static bool IsEmpty(this Vector3 v)
        {
            return v.X == 0 && v.Y == 0 && v.Z == 0; 
        }

        /// <summary>
        ///     Returns the perpendicular vector.
        /// </summary>
        public static Vector3 Perpendicular(this Vector3 v)
        {
            return new Vector3(-v.Y, v.X, v.Z);
        }

        /// <summary>
        ///     Returns the second perpendicular vector.
        /// </summary>
        public static Vector3 Perpendicular2(this Vector3 v)
        {
            return new Vector3(v.Y, -v.X, v.Z);
        }

        /// <summary>
        ///     Rotates the vector a set angle (angle in radians).
        /// </summary>
        public static Vector3 Rotated(this Vector3 v, float angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle); 

            return new Vector3((float)(v.X * c - v.Y * s), (float)(v.Y * c + v.X * s), v.Z);
        }

        /// <summary>
        ///     Returns the cross product Z value.
        /// </summary>
        public static float CrossProduct(this Vector3 self, Vector3 other)
        {
            return other.Y * self.X - other.X * self.Y;
        }

        /// <summary>
        ///     Returns Math#Degree
        /// </summary>
        public static float RadianToDegree(double angle)
        {
            return (float) (angle * (180.0 / Math.PI));
        }

        /// <summary>
        ///     Returns Math#Rad
        /// </summary>
        public static float DegreeToRadian(double angle)
        {
            return (float) (Math.PI * angle / 180.0);
        }

        /// <summary>
        ///     Returns the polar for vector angle (in Degrees).
        /// </summary>
        public static float Polar(this Vector3 v1)
        {
            if (Close(v1.X, 0, 0))
            {
                if (v1.Y > 0)
                {
                    return 90;
                }
                if (v1.Y < 0)
                {
                    return 270;
                }

                return 0;
            }

            var theta = RadianToDegree(Math.Atan((v1.Y) / v1.X));
            if (v1.X < 0)
            {
                theta = theta + 180;
            }
            if (theta < 0)
            {
                theta = theta + 360;
            }
            return theta;
        }

        /// <summary>
        ///     Returns the angle with the vector p2.
        /// </summary>
        public static float AngleBetween(this Vector3 p1, Vector3 p2)
        {
            var theta = p1.Polar() - p2.Polar();
            if (theta < 0)
            {
                theta = theta + 360;
            }
            if (theta > 180)
            {
                theta = 360 - theta;
            }
            return theta;
        }

        /// <summary>
        /// Returns the closest vector from a list.
        /// </summary>
        public static Vector3 Closest(this Vector3 v, List<Vector3> vList)
        {
            var result = new Vector3();
            var dist = float.MaxValue;

            foreach (var vector in vList)
            {
                var distance = Vector3.DistanceSquared(v, vector);
                if (distance < dist)
                {
                    dist = distance;
                    result = vector;
                }
            }

            return result;
        }

        /// <summary>
        ///     Returns the projection of the Vector3 on the segment.
        /// </summary>
        public static ProjectionInfo ProjectOn(this Vector3 point, Vector3 segmentStart, Vector3 segmentEnd)
        {
            var cx = point.X;
            var cy = point.Y;
            var ax = segmentStart.X;
            var ay = segmentStart.Y;
            var bx = segmentEnd.X;
            var by = segmentEnd.Y;
            var rL = ((cx - ax) * (bx - ax) + (cy - ay) * (by - ay)) /
                     ((float) Math.Pow(bx - ax, 2) + (float) Math.Pow(by - ay, 2));
            var pointLine = new Vector3(ax + rL * (bx - ax), ay + rL * (by - ay), point.Z);
            float rS;
            if (rL < 0)
            {
                rS = 0;
            }
            else if (rL > 1)
            {
                rS = 1;
            }
            else
            {
                rS = rL;
            }

            var isOnSegment = rS.CompareTo(rL) == 0;
            var pointSegment = new Vector3();
            pointSegment = isOnSegment ? pointLine : new Vector3(ax + rS * (bx - ax), ay + rS * (@by - ay), pointLine.Z);
            return new ProjectionInfo(isOnSegment, pointSegment, pointLine);
        }


        //From: http://social.msdn.microsoft.com/Forums/vstudio/en-US/e5993847-c7a9-46ec-8edc-bfb86bd689e3/help-on-line-segment-intersection-algorithm
        /// <summary>
        ///     Intersects two line segments.
        /// </summary>
        public static IntersectionResult Intersection(this Vector3 lineSegment1Start, Vector3 lineSegment1End, Vector3 lineSegment2Start, Vector3 lineSegment2End)
        {
            double deltaACy = lineSegment1Start.Y - lineSegment2Start.Y;
            double deltaDCx = lineSegment2End.X - lineSegment2Start.X;
            double deltaACx = lineSegment1Start.X - lineSegment2Start.X;
            double deltaDCy = lineSegment2End.Y - lineSegment2Start.Y;
            double deltaBAx = lineSegment1End.X - lineSegment1Start.X;
            double deltaBAy = lineSegment1End.Y - lineSegment1Start.Y;

            var denominator = deltaBAx * deltaDCy - deltaBAy * deltaDCx;
            var numerator = deltaACy * deltaDCx - deltaACx * deltaDCy;

            if (denominator == 0)
            {
                if (numerator == 0)
                {
                    // collinear. Potentially infinite intersection points.
                    // Check and return one of them.
                    if (lineSegment1Start.X >= lineSegment2Start.X && lineSegment1Start.X <= lineSegment2End.X)
                    {
                        return new IntersectionResult(true, lineSegment1Start);
                    }
                    if (lineSegment2Start.X >= lineSegment1Start.X && lineSegment2Start.X <= lineSegment1End.X)
                    {
                        return new IntersectionResult(true, lineSegment2Start);
                    }
                    return new IntersectionResult();
                }
                // parallel
                return new IntersectionResult();
            }

            var r = numerator / denominator;
            if (r < 0 || r > 1)
            {
                return new IntersectionResult();
            }

            var s = (deltaACy * deltaBAx - deltaACx * deltaBAy) / denominator;
            if (s < 0 || s > 1)
            {
                return new IntersectionResult();
            }

            return new IntersectionResult(
                true,
                new Vector3((float)(lineSegment1Start.X + r * deltaBAx), (float)(lineSegment1Start.Y + r * deltaBAy), lineSegment1Start.Z));
        }

        public static Object[] VectorMovementCollision(Vector3 startPoint1, Vector3 endPoint1, float v1, Vector3 startPoint2, float v2, float delay = 0f)
        {
            float sP1x = startPoint1.X,
                sP1y = startPoint1.Y,
                eP1x = endPoint1.X,
                eP1y = endPoint1.Y,
                sP2x = startPoint2.X,
                sP2y = startPoint2.Y;

            float d = eP1x - sP1x, e = eP1y - sP1y;
            float dist = (float) Math.Sqrt(d * d + e * e), t1 = float.NaN, t2 = float.NaN;
            float S = dist != 0f ? v1 * d / dist : 0, K = (dist != 0) ? v1 * e / dist : 0f;

            float r = sP2x - sP1x, j = sP2y - sP1y;
            var c = r * r + j * j;


            if (dist > 0f)
            {
                if (v1 == float.MaxValue)
                {
                    var t = dist / v1;
                    t1 = v2 * t >= 0f ? t : float.NaN;
                }
                else if (v2 == float.MaxValue)
                {
                    t1 = 0f;
                }
                else
                {
                    float a = S * S + K * K - v2 * v2, b = -r * S - j * K;

                    if (a == 0f)
                    {
                        if (b == 0f)
                        {
                            t1 = (c == 0f) ? 0f : float.NaN;
                        }
                        else
                        {
                            var t = -c / (2 * b);
                            t1 = (v2 * t >= 0f) ? t : float.NaN;
                        }
                    }
                    else
                    {
                        var sqr = b * b - a * c;
                        if (sqr >= 0)
                        {
                            var nom = (float) Math.Sqrt(sqr);
                            var t = (-nom - b) / a;
                            t1 = v2 * t >= 0f ? t : float.NaN;
                            t = (nom - b) / a;
                            t2 = (v2 * t >= 0f) ? t : float.NaN;

                            if (!float.IsNaN(t2) && !float.IsNaN(t1))
                            {
                                if(t1 >= delay && t2 >= delay)
                                    t1 = Math.Min(t1, t2);
                                else if (t2 >= delay)
                                    t1 = t2;
                            }
                        }
                    }
                }
            }
            else if (dist == 0f)
            {
                t1 = 0f;
            }

            return new Object[2] { t1, (!float.IsNaN(t1)) ? new Vector3(sP1x + S * t1, sP1y + K * t1, startPoint1.Z) : new Vector3() };
        }

        /// <summary>
        /// Returns the total distance of a path.
        /// </summary>
        public static float PathLength(this List<Vector3> path)
        {
            var distance = 0f;
            for (var i = 0; i < path.Count - 1; i++)
            {
                distance += path[i].Distance(path[i + 1]);
            }
            return distance;
        }


        /// <summary>
        /// Returns the two intersection points between two circles.
        /// </summary>
        public static Vector3[] CircleCircleIntersection(Vector3 center1, Vector3 center2, float radius1, float radius2)
        {
            var D = center1.Distance(center2);
            //The Circles dont intersect:
            if (D > radius1 + radius2)
            {
                return new Vector3[] { };
            }

            var A = (radius1 * radius1 - radius2 * radius2 + D * D) / (2 * D);
            var H = (float) Math.Sqrt(radius1 * radius1 - A * A);
            var Direction = (center2 - center1);
            Direction.Normalize();
            var PA = center1 + A * Direction;
            var S1 = PA + H * Direction.Perpendicular();
            var S2 = PA - H * Direction.Perpendicular();
            return new[] { S1, S2 };
        }


        public static bool Close(float a, float b, float eps)
        {
            if (eps == 0)
            {
                eps = (float) 1e-9;
            }
            return Math.Abs(a - b) <= eps;
        }

        /// <summary>
        ///     Calculates the distance to the Vector3.
        /// </summary>
        public static float Distance(this Vector3 v, Vector3 to, bool squared = false)
        {
            return squared ? Vector3.DistanceSquared(v, to) : Vector3.Distance(v, to);
        }

        /// <summary>
        /// Retursn the distance to the line segment.
        /// </summary>
        public static float Distance(this Vector3 point, Vector3 segmentStart, Vector3 segmentEnd, bool onlyIfOnSegment = false, bool squared = false)
        {
            var objects = point.ProjectOn(segmentStart, segmentEnd);

            if (objects.IsOnSegment || onlyIfOnSegment == false)
            {
                return squared
                    ? Vector3.DistanceSquared(objects.SegmentPoint, point)
                    : Vector3.Distance(objects.SegmentPoint, point);
            }
            return float.MaxValue;
        }


        public struct IntersectionResult
        {
            public bool Intersects;
            public Vector3 Point;

            public IntersectionResult(bool Intersects = false, Vector3 Point = new Vector3())
            {
                this.Intersects = Intersects;
                this.Point = Point;
            }
        }

        public struct ProjectionInfo
        {
            public bool IsOnSegment;
            public Vector3 LinePoint;
            public Vector3 SegmentPoint;

            public ProjectionInfo(bool isOnSegment, Vector3 segmentPoint, Vector3 linePoint)
            {
                IsOnSegment = isOnSegment;
                SegmentPoint = segmentPoint;
                LinePoint = linePoint;
            }
        }
    
    }
}
