using TMPro.EditorUtilities;
using UnityEngine;

namespace TDS.Game.Zombie
{
    public abstract class ZombieMovement : MonoBehaviour
    {
        [SerializeField] private ZombieAnimation _animation;

     
        
        public abstract void SetTarget(Transform target);

        protected void SetAnimationSpeed(float speed) =>
            _animation.SetSpeed(speed);
        

    }
}