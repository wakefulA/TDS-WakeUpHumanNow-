﻿using UnityEngine;

namespace TDS.Game.Zombie
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ZombieDirectMovement : ZombieMovement     //Monobeh
    {
        [SerializeField] private float _speed = 4;
        [SerializeField] private Transform _target;

        private Rigidbody2D _rb;
        private Transform _cachedTransform;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
                return;

            MoveToTarget();
            RotateToTarget();
        }

       private void OnDisable()
       { 
           SetVelocity(Vector2.zero);
       }

        public override void SetTarget(Transform target)
        {
            _target = target;

            if (_target == null)
                SetVelocity(Vector2.zero);
        }

        private bool IsTargetValid()
        { 
            return _target != null;
        }
        

        private void MoveToTarget()
        {
            //if (_target != null)
            //{
                Vector3 direction = (_target.position - _cachedTransform.position).normalized;
                SetVelocity((direction * _speed));
                
                //SetVelocity(direction * _speed);
                //}
        }

        private void RotateToTarget()
        {
            Vector3 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up = direction;
        }

        private void SetVelocity(Vector2 velocity) 
        {
            _rb.velocity = velocity;
            SetAnimationSpeed(velocity.magnitude);
        }
            
        
        
    }
}