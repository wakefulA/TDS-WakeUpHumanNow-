using System;
using TDS.Game.Objects;
using TDS.Game.UI;
using UnityEngine;

namespace TDS.Game.Shared
{
    public class CharacterUI : MonoBehaviour
    {
        [SerializeField] private HPBar _hpBar;

        private IHealth _health;

        private void Awake()
        {
            Construct(GetComponentInChildren<IHealth>());
        }

        private void OnDestroy()
        {
            if (_health != null)
            {
                _health.OnChanged -= HpChanged;
                HpChanged(_health.CurrentHp);
            }
        }

        private void Construct(IHealth health)
        {
            _health = health;

            if (_health != null)
            {
                _health.OnChanged += HpChanged;
                HpChanged(_health.CurrentHp);
                
            }
            
        }

        private void HpChanged(int currentHP)
        {
            float fillAmount = currentHP / (float) _health.MaxHp;
            _hpBar.SetFill01(fillAmount);
        }
    }
}