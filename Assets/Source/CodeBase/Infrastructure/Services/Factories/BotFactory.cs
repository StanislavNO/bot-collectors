using System.Collections.Generic;
using System.Linq;
using Source.CodeBase.Configs;
using Source.CodeBase.GameplayModels.Bot;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Infrastructure.Services.Factories
{
    public class BotFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly CollectorBot _prefab;
        private readonly List<CollectorBot> _bots;
        private readonly Transform _botsParent;

        public BotFactory(IPrefabsContainer prefabsContainer, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _prefab = prefabsContainer.Bot;
            _bots = new List<CollectorBot>();
            _botsParent = new GameObject("BotsContainer").transform;
        }

        public List<CollectorBot> Get(int count, Material material)
        {
            _prefab.gameObject.SetActive(false);
            _bots.Clear();
            
            for (var i = 0; i < count; i++)
            {
                var instance = _instantiator.InstantiatePrefab(
                    _prefab, Vector3.zero, Quaternion.identity, _botsParent);

                var bot = instance.GetComponent<CollectorBot>();
                bot.SetMaterial(material);
                _bots.Add(bot);
            }

            return _bots.ToList();
        }
    }
}