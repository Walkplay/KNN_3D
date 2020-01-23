using Assets.Source.UI.WindowHandler;
using Modules.KNN;
using UnityEngine;

namespace Assets.Source.UI
{
    public class TopBarController : AbstractContoller<ITopBarView>
    {

        public TopBarController(ITopBarView view, IKNNHandler handler) : base(view)
        {
            concreteView.Run += handler.Run;
        }

        private void Log(EWindowType str)
        {
            Debug.Log("[Contoller] " + str);
        }
    }
}