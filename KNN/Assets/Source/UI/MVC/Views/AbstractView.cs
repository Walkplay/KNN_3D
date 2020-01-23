using Assets.Source.UI.WindowHandler;
using UnityEngine;

namespace Assets.Source.UI
{
    public abstract class AbstractView : MonoBehaviour, IView
    {
        public EWindowType windowType;

        public void Close()
        {
            Destroy(this);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
