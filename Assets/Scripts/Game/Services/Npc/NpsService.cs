using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Game.Zombie;
using TDS.Game.Zombie.Base;
using Object = UnityEngine.Object;

namespace TDS.Game.Npc
{
    public class NpsService : INpsService
    {
        public event Action OnAllDead;

        private List<ZombieDeath> _zombies;
        public void Init()
        {
            ZombieStarter[] zombieStarters = Object.FindObjectsOfType<ZombieStarter>();

            foreach (ZombieStarter starter in zombieStarters)
                starter.Begin();

            _zombies = Object.FindObjectsOfType<ZombieDeath>().ToList();
            Subscrine();

        }

        public void Dispose()
        {
            Unsubscribe();
            _zombies = null;
        }

        private void Unsubscribe()
        {
            foreach (ZombieDeath zombieDeath in _zombies)
                zombieDeath.OnHappened -= OnZombieDead;
        }

        private void Subscrine()
        {
            foreach (ZombieDeath zombieDeath in _zombies)
                zombieDeath.OnHappened += OnZombieDead;


        }

        private void OnZombieDead(ZombieDeath zombieDeath)
        {
            zombieDeath.OnHappened -= OnZombieDead;
            _zombies.Remove(zombieDeath);

            if (_zombies.Count == 0)
            {
                OnAllDead?.Invoke();
            }
        }
    }

   
}