using System;
using UnityEngine;

namespace Source.CodeBase.Configs
{
    [Serializable]
    public class ResourceSpawnSetting
    {
        [field: SerializeField] public float SpawnRadius { get; private set; }
        [field: SerializeField] public LayerMask NotSpawnLayers { get; private set; }
    }
}