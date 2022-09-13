using System.Collections;
using TDS.Game.Manager;
using TDS.Game.Zombie;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;

        private Rigidbody2D _rb;
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

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;
            StartCoroutine(LifeTimeTimer());
        }

        IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);

            Destroy(gameObject);
        }

        
    }
}