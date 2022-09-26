using UnityEngine;
using UnityEngine.UI;

namespace TDS.Game.UI
{
    public class HPBar : MonoBehaviour

    {
        [SerializeField] private Image _fillImage;

        public void SetFill01(float fillAmount) =>
            _fillImage.fillAmount = fillAmount;


    }
}