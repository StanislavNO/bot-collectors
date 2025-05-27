using System;
using System.Collections.Generic;
using Source.CodeBase.Configs;
using Source.CodeBase.GameplayModels.GameplayResources;
using Source.CodeBase.View;
using UnityEngine;
using Zenject;

namespace Source.CodeBase.Controllers
{
    public class ResourceSpawner : IResourceFinder, IInitializable, IDisposable, ITickable
    {
        private readonly IStartSignal _startSignal;
        private readonly List<Resource> _enabledResources;
        private readonly Resource _prefab;

        public ResourceSpawner(
            IPrefabsContainer prefabsContainer,
            IStartSignal startSignal,
            List<Resource> startResources)
        {
            _startSignal = startSignal;
            _prefab = prefabsContainer.Resource;
            _enabledResources = new List<Resource>();
            _enabledResources.AddRange(startResources);
        }

        public void Initialize()
        {
            _startSignal.OnStartClicked += OnGameStarted;
        }


        public void Dispose()
        {
            _startSignal.OnStartClicked -= OnGameStarted;
        }

        public void Tick()
        {
        }

        public Resource FindFirstResource(Vector3 startPosition)
        {
            float distance = float.MaxValue;
            Resource target = null;
            
            foreach (var resource in _enabledResources)
            {
                if ((resource.Position - startPosition).magnitude < distance)
                {
                    distance = (resource.Position - startPosition).magnitude;
                    target = resource;
                }
            }
            
            _enabledResources.Remove(target);
            return target;
        }

        private void OnGameStarted()
        {
            
        }
    }
}