using Data;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Modules.Holders.PointHolder
{
    public class PointHolder : IPointHolder
    {
        private Dictionary<string, Point> classifiedP = new Dictionary<string, Point>();
        private Dictionary<string, Point> unClassifiedP = new Dictionary<string, Point>();

        public event Action<Point[], Point[]> holderUpdate;

        public int classesAmount => classifiedP.Count;

        public void Push(Point point)
        {
            if (point.Type < 0)
                unClassifiedP.Add(point.Name, point);
            else
                classifiedP.Add(point.Name, point);

            Update();
        }

        public void SetClass(Point point, int type)
        {
            if (!unClassifiedP.ContainsKey(point.Name))
            {
                Debug.LogError($"unClassifiedP does not contain key {point.Name}");
                return;
            }

            var tmp_P = unClassifiedP[point.Name];
            tmp_P.Type = type;

            //unClassifiedP.Remove(point.Name);
            classifiedP.Add(tmp_P.Name, tmp_P);
            Update();
        }

        public Point[] GetClassifiedPoints()
        {
            return classifiedP.Select(pair => pair.Value).ToArray();
        }

        public Point[] GetUnClassifiedPoints()
        {
            return unClassifiedP.Select(pair => pair.Value).ToArray();
        }

        private void Update()
        {
            holderUpdate(GetUnClassifiedPoints(), GetClassifiedPoints());
        }
    }
}
