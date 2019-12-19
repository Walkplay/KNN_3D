using Data;
using System;

namespace Assets.Source.UI
{
    public interface ICreatePointView : IView
    {
        event Action<Point> AddNewPoint;
    }
}