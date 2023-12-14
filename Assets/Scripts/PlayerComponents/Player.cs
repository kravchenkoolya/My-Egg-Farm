using System;
using FallingObjectLogic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace PlayerComponents
{
    [RequireComponent(typeof(Animator),typeof(PlayerMover))]
    public class Player : IPauseObject
    {
        public UnityEvent Dead;
        
        private InputManager _inputManager;
        private PlayerState _playerState;
      
        [SerializeField] private TextMeshProUGUI _healthCountText;
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private int _health;
        private void Awake()
        {
            UpdateHealthCountText();
            _inputManager = new InputManager();
            _inputManager.Enable();
            _playerState = PlayerState.Idle;
            _inputManager.Player.Press.started += StartMove;
            _inputManager.Player.Press.canceled += EndMove;
        }

        private void EndMove(InputAction.CallbackContext obj)
        {
            _playerState = PlayerState.Idle;
            _playerMover.enabled = false;
            _playerAnimator.ToIdle();
        }

        private void StartMove(InputAction.CallbackContext obj)
        {
            _playerState = PlayerState.Move;
            _playerMover.enabled = true;
            _playerAnimator.StartMove();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out FallingObject fallingObject))
            {
                
                if (fallingObject.gameObject.CompareTag("Health"))
                {
                    AddHealth(fallingObject.Damage);
                }
                else
                {
                    GetDamage(fallingObject.Damage);
                }
                Destroy(col.gameObject);
            }
        }
        public void GetDamage(byte damage)
        {
            if (_health - damage > 0)
            {
                _health = _health - damage;
            }
            else
            {
                _health = 0;
                Dead?.Invoke();
            }

            UpdateHealthCountText();
        }

        public void AddHealth(byte healthAdd)
        {
            _health += healthAdd;
            UpdateHealthCountText();
        }

        private void UpdateHealthCountText() => _healthCountText.text = _health.ToString();

        public override void Pause()
        {
            _playerState = PlayerState.Idle;
            _playerAnimator.ToIdle();
            _playerMover.enabled = false;
            _inputManager.Disable();
        }

        public override void Play()
        {
            _playerState = PlayerState.Idle;
            _inputManager.Enable();
        }

        [Serializable]
        private class PlayerAnimator
        {
            [SerializeField] private Animator _animator;
            public void StartMove() => _animator.SetBool("Move",true);
            public void ToIdle() => _animator.SetBool("Move",false);
        }

        private enum PlayerState
        {
            Idle=0,Move=1
        }
    }
}