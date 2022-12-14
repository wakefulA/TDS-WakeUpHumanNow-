using TDS.Game.InputService;
using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        [SerializeField] private float _speed = 4f;

        private Rigidbody2D _rb;

        private Transform _cachedTransform;
        private IInputService _inputService;

        public void Construct(IInputService inputService)
        {
            _inputService = inputService; // injection dep
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
           
        }

        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        private void Update()
        {
            if(_inputService == null)
                return;
            
            Move();
            Rotate();
        }

        private void Move()
        {
            //float horizontal = Input.GetAxisRaw("Horizontal");
            //float vertical = Input.GetAxisRaw("Vertical");

            //Vector2 direction = new Vector2(horizontal, vertical);
            var direction = _inputService.Axes;
            Vector3 moveDelta = direction* _speed;
            _rb.velocity = moveDelta;
            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            //Vector3 mousePosition = Input.mousePosition;
            //Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            //worldPoint.z = 0f;

            //Vector3 direction = worldPoint - _cachedTransform.position;
            _cachedTransform.up = _inputService.LookDirection;
        }
    }
}