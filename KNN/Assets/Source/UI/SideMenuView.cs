using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIElements;
using UnityEngine;
using UniRx;

namespace Assets.Source.UI
{
    public class SideMenuView : MonoBehaviour
    {
        [Header("Debug DI")]
        [SerializeField] private CreatePointView createPointView;
        [Space]
        [SerializeField] private RectTransform UnclassifiedContent;
        [SerializeField] private RectTransform ClassifiedContent;

        private PointListUnit pointUnit;
        private List<PointListUnit> points;

        private void Start()
        {
            points = new List<PointListUnit>();
            pointUnit = Resources.Load<PointListUnit>("Prefabs/PointListUnit"); // TODO: Refactor!!
            createPointView.NewPointCreated
                .Subscribe(point =>
                {
                    if (point.Type == -1)
                        InstantiatePointUnit(point, UnclassifiedContent);
                    else
                        InstantiatePointUnit(point, ClassifiedContent);
                }).AddTo(this);
        }

        private void InstantiatePointUnit(Point point, RectTransform parent)
        {
            var unit = Instantiate(pointUnit, parent);
            unit.Init(point);
            points.Add(unit);
        }
    }
}
