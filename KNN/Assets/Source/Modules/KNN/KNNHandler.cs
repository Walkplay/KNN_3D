using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Modules.Holders.PointHolder;
using UnityEngine;

namespace Modules.KNN
{
    public class KNNHandler : IKNNHandler
    {
        private readonly IPointHolder _pointHolder;
        private readonly Settings settings;

        public KNNHandler(IPointHolder pointHolder, Settings settings)
        {
            _pointHolder = pointHolder;
            this.settings = settings;
        }

        public List<Point> GetKNearest(Point point, int K)
        {
            var points = _pointHolder.GetClassifiedPoints();
            var count = points.Length;

            var distances = GetDistanceToAll(point, points);
            distances.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            if (K > count)
                K = count;

            var nearest = new List<Point>();
            for (int j = 0; j < count; ++j)
            {
                if (j < K || distances[j].Value == distances[j - 1].Value)
                    nearest.Add(distances[j].Key);
                else break;
            }
            return nearest;
        }

        public void Run()
        {
            var unClassP = _pointHolder.GetUnClassifiedPoints();

            foreach (var Upoint in unClassP)
            {
                var typeCount = new int[_pointHolder.classesAmount];
                var nearest = GetKNearest(Upoint, settings.K);

                foreach (var point in nearest)
                    typeCount[point.Type-1]++;

                var maxValue = typeCount.Max();
                var maxIndex = typeCount.ToList().IndexOf(maxValue);

                _pointHolder.SetClass(Upoint, maxIndex+1);
                Debug.Log($"{Upoint.Name} set class {maxIndex+1}");
            }
        }

        private List<KeyValuePair<Point, float>> GetDistanceToAll(Point focusP, Point[] points)
        {
            var dist = new List<KeyValuePair<Point, float>>();
            foreach (var point in points)
                dist.Add(new KeyValuePair<Point, float>(point, (focusP.Position - point.Position).magnitude));
            return dist;
        }

        [Serializable]
        public struct Settings
        {
            public int K;
            public Point[] unClassifiedP;
            public Point[] classifiedP;

            public Settings(int K, Point[] unClassifiedP = null, Point[] classifiedP = null)
            {
                this.K = K;
                this.unClassifiedP = unClassifiedP;
                this.classifiedP = classifiedP;
            }

        }
    }
}
