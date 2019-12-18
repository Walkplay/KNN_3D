namespace Assets.Source.UI.Contractor
{
    public class Contractor<T> : IContractor<T> where T : IView
    {
        private readonly AbstractView view;
        private readonly AbstractContoller<T> contoller;

        public Contractor(AbstractView view, AbstractContoller<T> contoller)
        {
            this.view = view;
            this.contoller = contoller;
        }

        public void Destroy()
        {
            contoller.Dispose();
        }

        public void Hide()
        {
            view.Hide();
        }

        public void Show()
        {
            view.Show();
        }
    }
}