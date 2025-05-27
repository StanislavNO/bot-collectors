using Source.CodeBase.GameplayModels.GameplayResources;
using UnityEngine;

namespace Source.CodeBase.Controllers
{
    public interface IResourceFinder
    {
        Resource FindFirstResource(Vector3 startPosition);
    }
}