using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D8
{
    struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public static bool operator ==(Location l, Location r)
            => (l.Y == r.X) && (l.Y == r.Y) && (l.Z == r.Z);
        public static bool operator !=(Location l, Location r)
            => (l.Y != r.X) || (l.Y != r.Y) ||(l.Z != r.Z);


        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
    }
}
