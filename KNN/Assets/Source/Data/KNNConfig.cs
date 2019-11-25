using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class KNNConfig : ScriptableObject
    {
        public int K = 0;
        public List<Point> unClassified = new List<Point>();
        public List<Point> classified = new List<Point>();
    }
}
