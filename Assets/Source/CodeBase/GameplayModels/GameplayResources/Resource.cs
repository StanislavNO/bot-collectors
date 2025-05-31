using System;
using UnityEngine;

namespace Source.CodeBase.GameplayModels.GameplayResources
{
    public class Resource : MonoBehaviour
    {
        public Action<Resource> OnCollected;
        
        [SerializeField] private ParticleSystem _spawnEffect;
        
        public Vector3 Position => transform.position;

        private void OnEnable()
        {
            transform.localScale = Vector3.one;
            _spawnEffect.Play();
        }

        public void Collect() => OnCollected?.Invoke(this);
    }
}