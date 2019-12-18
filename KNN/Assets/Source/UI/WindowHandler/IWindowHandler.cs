namespace Assets.Source.UI.WindowHandler
{
    public interface IWindowHandler
    {
        void OpenWindow(EWindowType windowType);
        void CloseWindow(EWindowType windowType, bool destory = false);
    }
}
