using System;
using System.Collections.Generic;
using Source.CodeBase.Configs;
using Source.CodeBase.GameData;
using Source.CodeBase.GameplayModels.GameplayResources;
using Source.CodeBase.Infrastructure.Services.Pool;
using Source.CodeBase.View;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Source.CodeBase.Controllers
{
    public class ResourceSpawner : IResourceFinder, IInitializable, IDisposable, ITickable
    {
        private const float SPAWN_SPEED = 2f;
        
        private readonly IStartSignal _startSignal;
        private readonly List<Resource> _enabledResources;
        private readonly Resource _prefab;
        private readonly Pool<Resource> _pool;
        private readonly Map _map;

        private readonly ResourceSpawnSetting _setting;

        private bool _isWork;
        private float _spawnTimer;

        public ResourceSpawner(
            IPrefabsContainer prefabsContainer,
            IStartSignal startSignal,
            List<Resource> startResources, Map map,
            GameSetting setting)
        {
            _startSignal = startSignal;
            _map = map;
            _setting = setting.ResourceSpawnSetting;
            _prefab = prefabsContainer.Resource;
            _enabledResources = new List<Resource>();
            _enabledResources.AddRange(startResources);
            _pool = new(Create);
        }

        public void Initialize() =>
            _startSignal.OnStartClicked += OnGameStarted;

        public void Dispose()
        {
            _startSignal.OnStartClicked -= OnGameStarted;

            foreach (var resource in _enabledResources)
                resource.OnCollected -= ResourceCollected;
        }

        public void Tick()
        {
            if (_isWork == false)
                return;

            _spawnTimer -= Time.deltaTime;

            if (_spawnTimer > 0)
                return;

            _spawnTimer = SPAWN_SPEED;
            Spawn();
        }

        public bool TryFindFirstResource(Vector3 startPosition, out Resource resource)
        {
            resource = null;

            if (_enabledResources.Count == 0)
                return false;

            float minDistance = int.MaxValue;
            Resource target = null;

            foreach (var item in _enabledResources)
            {
                var distance = Vector3.Distance(item.Position, startPosition);

                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = item;
                }
            }

            _enabledResources.Remove(target);
            resource = target;
            return true;
        }

        private void OnGameStarted() => _isWork = true;

        private void Spawn()
        {
            var resource = _pool.Get();
            resource.transform.position = FindFreePlace();
            resource.gameObject.SetActive(true);
            _enabledResources.Add(resource);

            resource.OnCollected += ResourceCollected;
        }

        private Vector3 FindFreePlace()
        {
            Vector3 place = Vector3.zero;

            while (place == Vector3.zero)
            {
                Vector3 randomPoint = GetRandomPointOnMap();

                if (!Physics.CheckSphere(randomPoint, _setting.SpawnRadius, _setting.NotSpawnLayers))
                    place = randomPoint;
            }

            return place;
        }

        private void ResourceCollected(Resource resource)
        {
            resource.OnCollected -= ResourceCollected;
            resource.gameObject.SetActive(false);
            _pool.Put(resource);
        }

        private Vector3 GetRandomPointOnMap()
        {
            var bounds = _map.Bounds;
            var yOffset = 2f;

            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.center.y + yOffset,
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        private Resource Create() =>
            Object.Instantiate(_prefab, _map.Transform);
    }
}