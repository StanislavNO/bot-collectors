using UnityEngine;

namespace Source.CodeBase.GameData
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private Transform _oneFractionSpawnPoint;
        [SerializeField] private Transform _twoFractionSpawnPoint;
        
        public Vector3 OneFractionSpawnPoint => _oneFractionSpawnPoint.position + Vector3.right;
        public Vector3 TwoFractionSpawnPoint => _twoFractionSpawnPoint.position + Vector3.left;
    }
}