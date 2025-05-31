using UnityEngine;

namespace Source.CodeBase.GameplayModels.Camera
{
    public class CameraBotFollower : MonoBehaviour
    {
        [SerializeField] private float _yOffset = 5;
        [SerializeField] private float _zOffset = -10;
        [SerializeField] private Vector3 _rotationEuler = new Vector3(30f, 0f, 0f);

        public void SetTarget(Transform target)
        {
            transform.SetParent(target);
            transform.localPosition = new Vector3(0, _yOffset, _zOffset);
            transform.localRotation = Quaternion.Euler(_rotationEuler);
        }
    }
}