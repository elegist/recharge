using System;
using UnityEngine;

namespace Recharge
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Automatically filled on reset")]
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        [Header("References")]
        [SerializeField]
        private InputManager _inputManager;

        [Header("Configuration")]
        [SerializeField]
        private float _accelerationSpeed = 5f;
        [SerializeField]
        private float _maxVelocity = 20f;

        private bool _isMoving;

        private void Reset()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _inputManager.OnMovePerformed += MovePerformed;
            _inputManager.OnMoveCanceled += MoveCanceled;
        }

        private void MoveCanceled()
        {
            _isMoving = false;
        }

        private void MovePerformed()
        {
            _isMoving = true;
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (_isMoving)
            {
                _rigidbody2D.AddForce(Vector2.right * _accelerationSpeed);
            }

            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, _maxVelocity);
        }
    }
}
