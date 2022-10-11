﻿using UnityEngine;

namespace TDS.Game.InputService
{
    public class StandaloneInputService : IInputService
    {

        private readonly Camera _mainCamera;
        private readonly Transform _playerMovementTransform;

        public Vector2 Axes => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical"));
        public Vector3 LookDirection => GetLookDirection();

        public StandaloneInputService(Camera camera, Transform playerMovementTransform)
        {
            _mainCamera = camera;
            _playerMovementTransform = playerMovementTransform;
        }

        private Vector3 GetLookDirection()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            return worldPoint - _playerMovementTransform.position;
        }
    }
}