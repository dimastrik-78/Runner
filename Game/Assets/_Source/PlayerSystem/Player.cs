using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace PlayerSystem
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private CapsuleCollider playerCollider;
        [SerializeField] private float speed;
        [SerializeField] private float jump;
        [SerializeField] private LayerMask obstacle;

        private const float MOVE_RIGHT = 1.5f;
        private const float MOVE_LEFT = -1.5f;

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
            if (obstacle.Contains(other.gameObject.layer))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void Init()
        {
            _playerInput = new PlayerInputs();

            _playerInput.Action.MoveRight.performed += _ => _movement.SidewaysMovement(MOVE_RIGHT, true);
            _playerInput.Action.MoveLeft.performed += _ => _movement.SidewaysMovement(MOVE_LEFT,  false);
            
            _playerInput.Action.Jump.performed += _ => _movement.Jump();
            
            _playerInput.Action.Squat.performed += _ => StartCoroutine(_movement.Squat());

            _movement = new Movement(rb, transform, playerCollider, speed, jump);
        }
    }
}