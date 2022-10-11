using TDS.Game.Player;
using TDS.Game.Zombie.Base;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieMoveToPlayer : ZombieFollow
    {
        [SerializeField] private ZombieMovement _movement;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerHealth>().transform;
        }

        public override void Activate()
        {
            base.Activate();
            SetTarget(_playerTransform);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            SetTarget(null);
        }

        //private void OnDisable()
        //{
           // SetTarget(null);
        //}

        //private void OnEntered(Collider2D col)
        //{ SetTarget(_playerTransform);
        //}

        //private void OnExited(Collider2D other)
        //{
        //    SetTarget(null);
        //}

        private void SetTarget(Transform target)
        {
            _movement.SetTarget(target);
        }
    }
}