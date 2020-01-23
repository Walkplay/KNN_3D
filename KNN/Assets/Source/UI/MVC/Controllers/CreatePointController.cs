using Data;
using Modules.Holders.PointHolder;
using System;

namespace Assets.Source.UI
{
    public class CreatePointController : AbstractContoller<ICreatePointView>, IDisposable
    {

        public CreatePointController(ICreatePointView view, IPointHolder pointHolder) : base(view)
        {
            concreteView.AddNewPoint += pointHolder.Push;
        }

        private void SavePoint(Point point)
        {

        }

        public void Dispose()
        {
            base.Dispose();

            concreteView.AddNewPoint -= SavePoint;
        }
    }
}