using Source.CodeBase.GameplayModels.GameplayResources;
using UnityEngine;

namespace Source.CodeBase.Controllers
{
    public interface IResourceFinder
    {
        bool TryFindFirstResource(Vector3 startPosition, out Resource resource);
    }
}