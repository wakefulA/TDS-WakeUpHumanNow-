using UnityEngine;

namespace TDS.Game.Zombie.Base
{
    public class ZombieAnimationMediator : MonoBehaviour
    {
        [SerializeField] private ZombieMeleeAttack _meleeAttack;
        
        public void PerformDamage()
        {
           
            _meleeAttack.PerformDamage();
        }
        
    }
}