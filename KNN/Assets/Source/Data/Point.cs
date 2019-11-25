using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public struct Point
    {
        public Vector3 Position { get; private set; }
        public int Type { get; set; }
        public string Name { get; set; }

        public Point(string name, float x, float y, float z, int type = -1)
        {
            Name = name;
            Position = new Vector3(x, y, z);
            Type = type;
        }
    }
}
