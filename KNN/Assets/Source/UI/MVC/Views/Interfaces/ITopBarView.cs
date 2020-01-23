using Assets.Source.UI.WindowHandler;
using Data;
using System;

namespace Assets.Source.UI
{
    public interface ITopBarView : IView
    {
        event Action Run;
    }
}