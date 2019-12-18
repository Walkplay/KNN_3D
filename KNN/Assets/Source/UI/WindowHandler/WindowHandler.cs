using Assets.Source.Installers;
using Assets.Source.UI.Contractor;
using System.Collections.Generic;

namespace Assets.Source.UI.WindowHandler
{
    public class WindowHandler : IWindowHandler
    {
        private IWindowContainer _windowContainer;

        private Dictionary<EWindowType, IContractor<IView>> contractors = new Dictionary<EWindowType, IContractor<IView>>();
        private Settings _settings;

        public WindowHandler(Settings settings, IWindowContainer windowContainer)
        {
            _settings = settings;
            _windowContainer = windowContainer;
        }

        public void CloseWindow(EWindowType windowType, bool destory = false)
        {
            if (destory)
            {
                contractors[windowType].Destroy();
                contractors.Remove(windowType);
            }
            else
            {
                contractors[windowType].Hide();
            }
        }

        public void OpenWindow(EWindowType windowType)
        {
            if (contractors.ContainsKey(windowType))
            {
                contractors[windowType].Show();
            }
            else
            {
                contractors.Add(windowType, _windowContainer.CreateContractor(windowType, _settings.prefabDictionary[windowType].ownCanvas));
            }
        }

        public struct Settings
        {
            public Dictionary<EWindowType, Window> prefabDictionary;

            public Settings(Dictionary<EWindowType, Window> dict)
            {
                prefabDictionary = dict;
            }
        }
    }
}