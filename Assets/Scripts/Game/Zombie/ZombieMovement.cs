using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieMovement : MonoBehaviour

    {
        private Transform _cachedTransform;
        private Camera _mainCamera;

        private void Awake()
        {
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            Vector3 direction = worldPoint - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}