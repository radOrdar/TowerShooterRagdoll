using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Services;
using Services.Audio;
using Services.Input;
using Services.PersistentProgress;
using Services.Randomizer;
using Services.SaveLoad;
using Services.StaticData;
using UI.Services.Factory;
using UI.Services.Windows;
using UnityEngine;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string AudioServicePrefabPath = "Static Data/Audio/AudioService";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }


        public void Exit()
        {
        
        }
        
        private void RegisterServices()
        {
            RegisterStaticDataService();
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IRandomService>(new RandomService());
            RegisterAudioService();
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>(),
                _services.Single<IStaticDataService>(), _services.Single<IPersistentProgressService>()));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));
            _services.RegisterSingle<IGameFactory>(new GameFactory());

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>(),
                _services.Single<IGameFactory>()));
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.Load();
            _services.RegisterSingle<IStaticDataService>(staticDataService);
        }

        private void RegisterAudioService()
        {
            AudioService audioService = _services.Single<IAssetProvider>().Instantiate(AudioServicePrefabPath).GetComponent<AudioService>();
            audioService.Construct(_services.Single<IRandomService>(), _services.Single<IStaticDataService>());
            _services.RegisterSingle<IAudioService>(audioService);
        }
        
        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }
        

    }
}