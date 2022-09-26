using System;
using TDS.Game.Zombie.Base;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieInstantBackToIdle : ZombieBackToIdle

    {
        [SerializeField] private ZombieIdle _idle;

        private void OnEnable()
        {
            _idle.enabled = true;
        }
    }
}