using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private CapsuleCollider playerCollider;
        [SerializeField] private float speed;
        [SerializeField] private float jump;
        [SerializeField] private LayerMask obstacle;

        private PlayerInputs _playerInput;
        private Movement _movement;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void FixedUpdate()
        {
            _movement.Move();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (obstacle == (obstacle | (1 << other.gameObject.layer)))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void Init()
        {
            _playerInput = new PlayerInputs();

            _playerInput.Action.MoveRight.performed += _ => _movement.SidewaysMovement(1.5f, true);
            _playerInput.Action.MoveLeft.performed += _ => _movement.SidewaysMovement(-1.5f,  false);
            
            _playerInput.Action.Jump.performed += _ => _movement.Jump();
            
            _playerInput.Action.Squat.performed += _ => StartCoroutine(_movement.Squat());

            _movement = new Movement(rb, transform, playerCollider, speed, jump);
        }
    }
}