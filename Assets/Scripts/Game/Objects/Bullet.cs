using System.Collections;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 3f;

        private Rigidbody2D _rb;
        private int _damage;
        public LayerMask whatIsSolid;

        private void Update()
        {
            Transform transform1 = transform;
            RaycastHit2D hitInfo = Physics2D.Raycast(transform1.position, transform1.up, 1, whatIsSolid);
            if (hitInfo.collider != null &&  hitInfo.collider.CompareTag("Player"))

            {
                Player.Player.Instance.ChangeHealth(damage:1);
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