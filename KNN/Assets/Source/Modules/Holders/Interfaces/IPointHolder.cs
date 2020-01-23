using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Holders.PointHolder
{
    public interface IPointHolder
    {
        event Action<Point[], Point[]> holderUpdate; // unclassified, classified

        int classesAmount { get; }


        void Push(Point point);
        void SetClass(Point point, int type);
        Point[] GetClassifiedPoints();
        Point[] GetUnClassifiedPoints();
    }
}
