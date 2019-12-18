using Assets.Source.UI.WindowHandler;
using Data;
using System;

namespace Assets.Source.UI
{
    public interface ISideMenuView : IView
    {
        void AddPointUnit(Point point);

        event Action<EWindowType> OpenWindowEvent;
    }
}