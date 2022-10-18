using System;
using TDS.Game.Zombie.Base;
using UnityEngine;

namespace TDS.Game.Zombie
{
    
    [RequireComponent(typeof(ZombieFollowAgro))]
    [RequireComponent(typeof(ZombieAttackAgro))]
    
    public class ZombieStarter : MonoBehaviour

    {
        [SerializeField] private ZombieIdle _idle;

      

        public void Begin()
        {
            _idle.Activate();
        }
    }
}