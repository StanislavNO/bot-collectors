using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.GameplayModels.GameplayResources;

namespace Source.CodeBase.Configs
{
    public interface IPrefabsContainer
    {
        public CollectorBot Bot { get;}
        public Resource Resource { get;}
    }
}