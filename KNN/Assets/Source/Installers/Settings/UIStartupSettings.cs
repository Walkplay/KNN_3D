using Assets.Source.Installers;
using Assets.Source.UI;
using Assets.Source.UI.Contractor;
using Assets.Source.UI.WindowHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UIStartupSettings", menuName = "Installers/UIStartupSettings")]
public class UIStartupSettings : ScriptableObjectInstaller<UIStartupSettings>, IWindowContainer
{
    [SerializeField] private GameObject defaultCanvasPrefab;
    [SerializeField, Tooltip("UI needed only for this scene")] private Window[] ContextUIList;

    private Dictionary<EWindowType, Window> prefabDictionary;
    private RectTransform defaultCanvas;
    private WindowHandler _windowHandler;

    public override void InstallBindings()
    {
        defaultCanvas = Instantiate(defaultCanvasPrefab).GetComponent<RectTransform>();
        prefabDictionary = ContextUIList.ToDictionary(view => view.prefab.windowType);
        var settings = new WindowHandler.Settings(prefabDictionary);
        _windowHandler = new WindowHandler(settings, this);
        Container.Bind<WindowHandler.Settings>().FromInstance(settings).AsSingle();
        Container.Bind<IWindowHandler>().FromInstance(_windowHandler).AsSingle();
        Start();
    }

    public IContractor<IView> CreateContractor(EWindowType type, bool selfCanvas = false)
    {
        var parent = selfCanvas ? Instantiate(defaultCanvasPrefab).GetComponent<RectTransform>() : defaultCanvas;

        switch (type)
        {
            case EWindowType.SideMenu:
                var sideMenu = Container.InstantiatePrefabForComponent<SideMenuView>(prefabDictionary[type].prefab, parent);
                Container.Bind<ISideMenuView>().FromInstance(sideMenu).AsSingle();
                Container.Bind<SideMenuController>().AsSingle();
                var sideMenuController = Container.Instantiate<SideMenuController>();
                return new Contractor<ISideMenuView>(sideMenu, sideMenuController);
            case EWindowType.CreatePoint:
                var createPoint = Container.InstantiatePrefabForComponent<CreatePointView>(prefabDictionary[type].prefab, parent);
                Container.Bind<ICreatePointView>().FromInstance(createPoint).AsSingle();
                Container.Bind<CreatePointController>().AsSingle();
                var createPointController = Container.Instantiate<CreatePointController>();
                return new Contractor<ICreatePointView>(createPoint, createPointController);
            default:
                return null;
        }
    }


    private void Start()
    {
        if (ContextUIList.Length == 0) return;
        foreach (var window in ContextUIList)
            if (window.enableOnStart)
                _windowHandler.OpenWindow(window.prefab.windowType);
    }

}

[Serializable]
public struct Window
{
    public AbstractView prefab;
    public bool ownCanvas;
    public bool enableOnStart;

    public Window(AbstractView prefab, bool alone = false, bool enableOnStart = false)
    {
        this.prefab = prefab;
        this.ownCanvas = alone;
        this.enableOnStart = enableOnStart;
    }
}