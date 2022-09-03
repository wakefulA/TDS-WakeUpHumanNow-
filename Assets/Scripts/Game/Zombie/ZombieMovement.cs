using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieMovement : MonoBehaviour

    {
        private Transform _cachedTransform;
        private Camera _mainCamera;

        private Transform _playerTransform;

        private void Awake()
        {
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            Vector3 direction = _playerTransform.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }
    }
}