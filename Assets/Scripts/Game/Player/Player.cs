using TDS.Game.Manager;
using UnityEngine;


namespace TDS.Game.Player
{
    public class Player : SingletonMonoBehaviour<Player>

    {
        [SerializeField] public int _health;

        private void Update()
        {
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void ChangeHealth(int damage)
        {
            _health -= damage;
        }
    }
}