using UnityEngine;

namespace Source.CodeBase.GameData
{
    public class Map : MonoBehaviour
    {
        [SerializeField] private float _spawnBaseOffset = 2;
        [SerializeField] private Transform _oneFractionSpawnPoint;
        [SerializeField] private Transform _twoFractionSpawnPoint;
        [SerializeField] private Collider _collider;

        [field: SerializeField] public Transform Transform { get; private set; }
        
        public Bounds Bounds => _collider.bounds;
        
        public Vector3 OneHomePosition => _oneFractionSpawnPoint.position;
        public Vector3 TwoHomePosition => _twoFractionSpawnPoint.position;
        
        public Vector3 OneFractionSpawnPoint =>
            _oneFractionSpawnPoint.position + Vector3.right * _spawnBaseOffset;

        public Vector3 TwoFractionSpawnPoint =>
            _twoFractionSpawnPoint.position + Vector3.left * _spawnBaseOffset;
    }
}