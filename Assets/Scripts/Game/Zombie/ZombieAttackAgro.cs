using System;
using TDS.Game.Zombie.Base;
using Unity.VisualScripting;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieAttackAgro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private ZombieAttack _attack;
        [SerializeField] private ZombieFollow _follow;
        //private bool _isInRange;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        //private void Update()
        //{
           // if (_isInRange)
             //   _attack.Attack();
       // }

        private void OnDestroy()
        {
            _triggerObserver.OnEntered -= OnEntered;
            _triggerObserver.OnExited -= OnExited;
        }

        private void OnEntered(Collider2D col)
        {
            //_isInRange = true;
            _follow.Deactivate();
            _attack.Activate();
        }

        private void OnExited(Collider2D col)
        {
            _attack.Deactivate();
            //_isInRange = false;
            _follow.Activate();
        }
    }
}