using System.Collections;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieCopAttack : MonoBehaviour

    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField] private float _startTimeSpawn = 3f;
        [SerializeField] private float _currentTimeSpawn = 0.5f;

        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Start()
        {
            StartCoroutine(SpawnWeaponRoutine());
        }

        private void Attack()
        {
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position, _cachedTransform.rotation);
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