﻿using Lean.Pool;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _fireDelay = 0.3f;

        private Transform _cachedTransform;
        private float _delayTimer;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            if (CanAttack())
            {
                Attack();
            }

            TickTimer();
        }

        private bool CanAttack()
        {
            return Input.GetButton("Fire1") && _delayTimer <= 0;
        }

        private void Attack()
        {
            _playerAnimation.PlayShoot();
            LeanPool.Spawn(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            _delayTimer = _fireDelay;
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }
    }
}