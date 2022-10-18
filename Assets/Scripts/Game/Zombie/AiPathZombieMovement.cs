using Pathfinding;
using UnityEngine;

namespace TDS.Game.Zombie
{
    [RequireComponent(typeof(AIDestinationSetter))]
    [RequireComponent(typeof(Seeker))]
    
    public class AiPathZombieMovement : ZombieMovement
    {
        
        [Header(nameof(AiPathZombieMovement))]
        
        [SerializeField] private AIDestinationSetter _destinationSetter;
        [SerializeField] private AIBase _aiPath;
        
        public float Speed { get; set; }

        private void Start()
        {
            _aiPath.maxSpeed = Speed;
        }

        

        private void Update()
        {
            if (_destinationSetter.target != null)
            {
                SetAnimationSpeed(_aiPath.velocity.magnitude);
            }
        }

        public override void SetTarget(Transform target)
        {
            _destinationSetter.target = target;
            _aiPath.canMove = target != null;

            if (target == null)
            {
                SetAnimationSpeed(0);
            }
        }
    }
}