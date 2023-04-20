using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void FixedUpdate()
        {
            transform.position = new Vector3(0, 1, transform.position.z + speed * Time.deltaTime);
        }
    }
}
