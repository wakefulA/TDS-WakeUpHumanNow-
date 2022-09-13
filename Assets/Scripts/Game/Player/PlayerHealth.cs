﻿using System;
using TDS.Game.Objects;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [SerializeField] public int _startHp;
        [SerializeField] private int _maxHp;
      
        

        public event Action<int> OnChanged; 

        public int CurrentHp { get; private set; }
        public int MaxHp => _maxHp;

        private void Awake()
        {
            CurrentHp = _startHp;
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyDamage(int damage)
        {
            CurrentHp = Mathf.Max(0, CurrentHp - damage);
            OnChanged?.Invoke(CurrentHp);
        }

        public void ApplyHeal(int heal)
        {
            CurrentHp = Mathf.Min(_maxHp, CurrentHp + heal);
            OnChanged?.Invoke(CurrentHp);
        }
        

      //  private void Update()
      // {
      //  if (_health <= 0)
      //  {
      //     Destroy(gameObject);
                
      // TODO : Play death animation
      //     }
      //  }
      //public void ChangeHealth(int damage)
    //  {
     // _health -= damage;
     //// }

     // private void Update()
     // {
      //    if (_health <= 0)
       //   {
       //       Destroy(gameObject);
         // }
     // }
    }
}