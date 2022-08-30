using System.Collections;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieAttack : MonoBehaviour

    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _fireDelay = 0.4f;
        [SerializeField] private float _startTimeSpawn = 3f;
        [SerializeField] private float _currentTimeSpawn = 0.5f;

        private Transform _cachedTransform;
        private float _delayTimer;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Start()
        {
            StartCoroutine(SpawnWeaponRoutine());
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
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
            _delayTimer = _fireDelay;
        }

        private void TickTimer()
        {
            _delayTimer -= Time.deltaTime;
        }

        private IEnumerator SpawnWeaponRoutine()
        {
            yield return new WaitForSeconds(_startTimeSpawn);

            while (true)
            {
                Attack();

                yield return new WaitForSeconds(_currentTimeSpawn);
            }
        }
    }
}