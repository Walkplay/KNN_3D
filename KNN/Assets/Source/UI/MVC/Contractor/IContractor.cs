namespace Assets.Source.UI.Contractor
{
    public interface IContractor<out T> where T : IView
    {
        void Show();

        void Hide();

        void Destroy();
    }
}