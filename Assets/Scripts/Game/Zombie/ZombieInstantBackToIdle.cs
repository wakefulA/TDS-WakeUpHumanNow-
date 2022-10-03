using System;
using TDS.Game.Zombie.Base;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public class ZombieInstantBackToIdle : ZombieBackToIdle

    {
        [SerializeField] private ZombieIdle _idle;

        public override void Activate()
        {
            base.Activate();
            Deactivate();
            _idle.Activate();
        }
    }
}