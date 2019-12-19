using Modules.Holders.PointHolder;
using Modules.KNN;
using Zenject;

namespace Assets.Source.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public KNNHandler.Settings settings;

        public override void InstallBindings()
        {

            Container.Bind<IPointHolder>().To<PointHolder>().AsSingle();
            Container.Bind<IKNNHandler>().To<KNNHandler>().AsSingle();
            Container.Bind<KNNHandler.Settings>().FromInstance(settings).AsSingle();
            
            
        }
    }
}