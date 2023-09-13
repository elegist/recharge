using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Recharge
{
    [CreateAssetMenu(fileName = "InputManager", menuName = "recharge/InputManager", order = 0)]
    public class InputManager : ScriptableObject, PlayerControls.IGameplayActions
    {
        private PlayerControls _playerControls;

        public event Action OnMovePerformed;
        public event Action OnMoveCanceled;

        public event Action OnInteractPerformed;

        private void OnEnable()
        {
            if (_playerControls == null)
            {
                _playerControls = new PlayerControls();

                _playerControls.Gameplay.SetCallbacks(this);

                _playerControls.Gameplay.Enable();
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    break;
                case InputActionPhase.Waiting:
                    break;
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    OnMovePerformed?.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    OnMoveCanceled?.Invoke();
                    break;
                default:
                    break;
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Disabled:
                    break;
                case InputActionPhase.Waiting:
                    break;
                case InputActionPhase.Started:
                    break;
                case InputActionPhase.Performed:
                    OnInteractPerformed?.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    break;
                default:
                    break;
            }
        }

        private void OnDisable()
        {
            _playerControls.Gameplay.Disable();
        }
    }
}