using System.Collections.Generic;
using Source.CodeBase.Controllers;
using Source.CodeBase.GameData;
using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.GameplayModels.Bot.BotFSM;
using Source.CodeBase.GameplayModels.Camera;
using Source.CodeBase.GameplayModels.GameplayResources;
using Source.CodeBase.Infrastructure.Services.Factories;
using Source.CodeBase.View;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private List<Resource> _startResources;
        [SerializeField] private StartPanel _startPanel;
        [SerializeField] private HeadUpDisplay _headUpDisplay;
        [SerializeField] private Map _map;
        [SerializeField] private CameraBotFollower _cameraBotFollower;

        public override void InstallBindings()
        {
            BindCamera();
            BindScore();
            BindView();
            BindEnvironment();
            BindData();
            BindBotMediator();
            BindFactories();
            BindBotFSM();
            BindControllers();
        }

        private void BindCamera()
        {
            Container.BindInstance(_cameraBotFollower).AsSingle();
            Container.BindInterfacesTo<BotCameraSetter>().AsSingle().NonLazy();
        }

        private void BindScore()
        {
            Container.BindInterfacesAndSelfTo<Score>().AsSingle();
        }

        private void BindBotMediator()
        {
            Container.Bind<BotMediator>().ToSelf().AsTransient();
        }

        private void BindBotFSM()
        {
            Container.BindInterfacesAndSelfTo<BotStateMachine>().AsTransient();
        }

        private void BindEnvironment()
        {
            Container.BindInstance(_map).AsSingle();
            Container.BindInstance(_startResources).AsSingle();
        }

        private void BindData()
        {
            Container.BindInterfacesAndSelfTo<SessionData>().AsSingle();
            Container.Bind<BotData>().AsTransient();
        }

        private void BindView()
        {
            Container.BindInterfacesAndSelfTo<StartPanel>().FromInstance(_startPanel);
            Container.BindInterfacesAndSelfTo<HeadUpDisplay>().FromInstance(_headUpDisplay);
        }

        private void BindControllers()
        {
            Container.BindInterfacesTo<ViewController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BotSpawner>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ResourceSpawner>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<BotFactory>().AsSingle();
        }
    }
}