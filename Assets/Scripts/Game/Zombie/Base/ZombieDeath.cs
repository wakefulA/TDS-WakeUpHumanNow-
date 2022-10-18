using System;
using UnityEngine;

namespace TDS.Game.Zombie.Base
{
    public class ZombieDeath : MonoBehaviour
    {
        public event Action<ZombieDeath> OnHappened;
    }
}