using Assets.Source.UI;
using Assets.Source.UI.Contractor;
using Assets.Source.UI.WindowHandler;

namespace Assets.Source.Installers
{
    public interface IWindowContainer
    {
        IContractor<IView> CreateContractor(EWindowType type, bool selfCanvas = false);
    }
}