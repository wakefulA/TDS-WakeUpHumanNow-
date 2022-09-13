
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieApplyHp : MonoBehaviour
    {
        [SerializeField] private ZombieHp _zombieHp;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            
            Debug.Log($" {col.gameObject.name}");
            _zombieHp.ApplyDamage(1);
        }
    }
}