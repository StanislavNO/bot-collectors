using System.Collections.Generic;
using Source.CodeBase.GameplayModels.GameplayResources;
using UnityEngine;

namespace Source.CodeBase.Controllers
{
    public class ResourceSpawner : IResourceFinder
    {
        private readonly List<Resource> _enabledResources;
        
        public ResourceSpawner()
        {
            _enabledResources = new List<Resource>();
        }

        public Resource FindFirstResource(Vector3 startPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}