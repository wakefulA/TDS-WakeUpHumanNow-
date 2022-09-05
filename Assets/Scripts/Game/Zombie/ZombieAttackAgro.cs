using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieAttackAgro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private ZombieAttack _attack;
        [SerializeField] private ZombieMovement _zombieMovement;
        private bool _isInRange;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void Update()
        {
            if (_isInRange)
                _attack.Attack();
        }

        private void OnEntered(Collider2D col)
        {
            _isInRange = true;
            _zombieMovement.enabled = false;
        }

        private void OnExited(Collider2D col)
        {
            _isInRange = false;
            _zombieMovement.enabled = true;
        }
    }
}