using Source.CodeBase.GameplayModels.Bot;
using Source.CodeBase.GameplayModels.GameplayResources;
using UnityEngine;

namespace Source.CodeBase.Configs
{
    [CreateAssetMenu(menuName = "Game Setting", fileName = "Game Setting")]
    public class GameSetting : ScriptableObject, IPrefabsContainer
    {
        [field: SerializeField] public CollectorBot Bot { get; private set; }
        [field: SerializeField] public Resource Resource { get; private set; }
        [field: SerializeField] public Material OneFractionMaterial { get; private set; }
        [field: SerializeField] public Material TwoFractionMaterial { get; private set; }
        [field: SerializeField] public ResourceSpawnSetting ResourceSpawnSetting { get; private set; }
    }
}