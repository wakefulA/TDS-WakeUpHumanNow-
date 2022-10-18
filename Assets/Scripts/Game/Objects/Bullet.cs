using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using TDS.Game.Manager;
using TDS.Game.Zombie;
using Unity.VisualScripting;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;
        [SerializeField] private int _damage = 1;

        private Rigidbody2D _rb;
        private IEnumerator _lifeTimeRoutine;
        public int heal;
        public LayerMask whatIsSolid;

        private void Update()
        {
            Transform transform1 = transform;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform1.position, transform1.up, 1, whatIsSolid);
            if (hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))

            {
                hitInfo.collider.GetComponent<Player.PlayerHealth>().ApplyHeal(heal);
                Destroy(gameObject);
            }

        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            ZombieHp zombieHp = col.gameObject.GetComponentInParent<ZombieHp>();
            zombieHp.ApplyDamage(_damage);
            Despawn();
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
          
        }

        private void OnEnable()
        {
        
            _rb.velocity = transform.up * _speed;
            _lifeTimeRoutine = LifeTimeTimer();
            StartCoroutine(_lifeTimeRoutine);
        }

        private void OnDisable()
        {
            if (_lifeTimeRoutine != null)
            {
                StopCoroutine(_lifeTimeRoutine);
                _lifeTimeRoutine = null;
            }
        }

        IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            Despawn();
        }

        private void Despawn()
        {
            LeanPool.Despawn(gameObject);
        }
    }
}