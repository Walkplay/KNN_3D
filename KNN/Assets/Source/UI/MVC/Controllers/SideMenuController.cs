using Assets.Source.UI.WindowHandler;
using UnityEngine;

namespace Assets.Source.UI
{
    public class SideMenuController : AbstractContoller<ISideMenuView>
    {
        private readonly IWindowHandler _windowHandler;

        public SideMenuController(ISideMenuView sideMenuView, IWindowHandler windowHandler) : base(sideMenuView)
        {
            _windowHandler = windowHandler;
            sideMenuView.OpenWindowEvent += _windowHandler.OpenWindow;
            sideMenuView.OpenWindowEvent += Log;
        }

        private void Log(EWindowType str)
        {
            Debug.Log("[Contoller] " + str);
        }
    }
}