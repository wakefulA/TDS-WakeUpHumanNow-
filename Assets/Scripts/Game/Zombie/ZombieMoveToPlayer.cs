using TDS.Game.Player;
using TDS.Game.Zombie.Base;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieMoveToPlayer : ZombieFollow
    {
        [SerializeField] private ZombieMovement _movement;
        [SerializeField] private TriggerObserver _triggerObserver;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHealth>().transform;
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            SetTarget(_playerTransform);
        }

        private void OnExited(Collider2D other)
        {
            SetTarget(null);
        }

        private void SetTarget(Transform target)
        {
            _movement.SetTarget(target);
        }
    }
}