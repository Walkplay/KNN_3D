using Assets.Source.UI.WindowHandler;
using Data;
using System;

namespace Assets.Source.UI
{
    public interface ISideMenuView : IView
    {
        void AddPointUnit(Point point);
        void RefreshContent(Point[] unclassified, Point[] classified);

        event Action<EWindowType> OpenWindowEvent;
    }
}