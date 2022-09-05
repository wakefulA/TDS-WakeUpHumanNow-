using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieAttack : MonoBehaviour
    {
        [SerializeField] private int _damage = 2;

        [SerializeField] private float _attackDelay;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private float _delayTimer;

        private void Update()
        {
            TickTimer();
        }

        private void TickTimer() =>
            _delayTimer -= Time.deltaTime;

        public void Attack()
        {
            if (CanAttack())
                AttackInternal();
        }

        private bool CanAttack() =>
            _delayTimer <= 0;

        private void AttackInternal()
        {
            _delayTimer = _attackDelay;
            Collider2D coll = Physics2D.OverlapCircle(_attackPoint.position, _radius, _layerMask);
            if (coll == null)
                return;

            PlayerHealth playerHealth = coll.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.ApplyDamage(_damage);
        }
    }
}