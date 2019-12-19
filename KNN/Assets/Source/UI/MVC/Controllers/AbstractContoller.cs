using System;

namespace Assets.Source.UI
{
    public class AbstractContoller<TIView> : IDisposable where TIView : IView
    {
        protected readonly TIView concreteView;

        public AbstractContoller(TIView view)
        {
            concreteView = view;
        }

        public virtual void Dispose()
        {
            concreteView.Close();
        }
    }
}