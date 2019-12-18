using Assets.Source.UI.WindowHandler;
using Data;
using System;
using System.Collections.Generic;
using UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.UI
{
    public class SideMenuView : AbstractView, ISideMenuView
    {
        [SerializeField] private readonly RectTransform UnclassifiedContent;
        [SerializeField] private readonly RectTransform ClassifiedContent;
        [SerializeField] private Button AddNewBtn;

        private PointListUnit pointUnit;
        private List<PointListUnit> points;

        public event Action<EWindowType> OpenWindowEvent;

        private void Start()
        {
            points = new List<PointListUnit>();
            pointUnit = Resources.Load<PointListUnit>("Prefabs/PointListUnit"); // TODO: Refactor!!
            OpenWindowEvent += TEst;
            AddNewBtn.onClick.AddListener(() => OpenWindowEvent?.Invoke(EWindowType.CreatePoint));
        }

        public void TEst(EWindowType t)
        {
            Debug.Log("Test " + t);
        }

        public void AddPointUnit(Point point)
        {
            if (point.Type == -1)
            {
                InstantiatePointUnit(point, UnclassifiedContent);
            }
            else
            {
                InstantiatePointUnit(point, ClassifiedContent);
            }
        }

        private void InstantiatePointUnit(Point point, RectTransform parent)
        {
            var unit = Instantiate(pointUnit, parent);
            unit.Init(point);
            points.Add(unit);
        }

        public void Close()
        {
            Destroy(transform);
        }
    }
}