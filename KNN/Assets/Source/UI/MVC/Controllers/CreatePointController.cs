using System;

namespace Assets.Source.UI
{
    public class CreatePointController : AbstractContoller<ICreatePointView>, IDisposable
    {
        private readonly ICreatePointView _view;

        public CreatePointController(ICreatePointView view) : base(view)
        {
            _view = view;
        }

        public void Dispose()
        {
            _view.Close();
        }
    }
}