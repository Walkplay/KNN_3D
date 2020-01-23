using Assets.Source.UI.WindowHandler;
using Modules.Holders.PointHolder;
using UnityEngine;

namespace Assets.Source.UI
{
    public class SideMenuController : AbstractContoller<ISideMenuView>
    {
        private readonly IWindowHandler _windowHandler;

        public SideMenuController(ISideMenuView sideMenuView, IWindowHandler windowHandler, IPointHolder pointHolder) : base(sideMenuView)
        {
            _windowHandler = windowHandler;
            pointHolder.holderUpdate += concreteView.RefreshContent;
            sideMenuView.OpenWindowEvent += _windowHandler.OpenWindow;
        }

    }
}