using System.Collections;
using UnityEngine;

namespace PlayerSystem
{
    public class Movement
    {
        private readonly Rigidbody _playerRb;
        private readonly Transform _playerTransform;
        private readonly CapsuleCollider _collider;
        private readonly float _speed;
        private readonly float _jump;

        private const float STOP_POSITION_LEFT = -1.5f;
        private const float STOP_POSITION_RIGHT = 1.5f;

        public Movement(Rigidbody playerRb, Transform playerTransform, CapsuleCollider collider, float speed, float jump)
        {
            _playerRb = playerRb;
            _playerTransform = playerTransform;
            _collider = collider;
            _speed = speed;
            _jump = jump;
        }
        
        public void Move()
        {
            _playerRb.MovePosition(_playerRb.position + Vector3.forward * (_speed * Time.deltaTime));
        }

        public void SidewaysMovement(float switchPosition, bool check)
        {
            var position = _playerTransform.position;
            if ((position.x == STOP_POSITION_LEFT
                 && !check)
                || (position.x == STOP_POSITION_RIGHT
                && check))
            {
                return;
            }

            _playerTransform.position = new Vector3(position.x + switchPosition, position.y, position.z);
        }

        public void Jump()
        {
            _playerRb.AddForce(Vector3.up * _jump, ForceMode.Impulse);
        }

        public IEnumerator Squat()
        {
            _collider.height = 1;
            
            var pos = _playerTransform.position;
            _playerTransform.position = new Vector3(pos.x, pos.y - 0.5f, pos.z);

            yield return new WaitForSeconds(1f);
            
            _collider.height = 2;

            pos = _playerTransform.position;
            _playerTransform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        }
    }
}