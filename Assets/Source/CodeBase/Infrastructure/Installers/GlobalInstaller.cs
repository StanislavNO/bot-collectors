using Source.CodeBase.Configs;
using Source.CodeBase.Infrastructure.Services.AnimationService;
using Source.CodeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private GameSetting _gameSetting;

        public override void InstallBindings()
        {
            BindConfigs();
            BindInputService();
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<AnimationService>().AsSingle();
        }

        private void BindInputService()
        {
            Container.BindInterfacesTo<StandaloneInput>().AsSingle();
        }

        private void BindConfigs()
        {
            Container
                .BindInterfacesAndSelfTo<GameSetting>()
                .FromInstance(_gameSetting)
                .AsSingle();
        }
    }
}