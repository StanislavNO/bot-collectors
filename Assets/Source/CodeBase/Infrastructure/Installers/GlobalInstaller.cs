using Source.CodeBase.Configs;
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
        }

        private void BindInputService()
        {
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