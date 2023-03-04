using Infrastructure.AssetManagement;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData.WIndows;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;

namespace UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        private Transform _uiRoot;
        private readonly IPersistentProgressService _progressService;

        public UIFactory(IAssetProvider assets, IStaticDataService staticData, IPersistentProgressService progressService)
        {
            _assets = assets;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void CreateSomeUI()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.SomeUI);
            WindowBase window = Object.Instantiate(config.Template, _uiRoot);
            window.Construct();
        }
        
        public void CreateUIRoot() =>
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
    }
}