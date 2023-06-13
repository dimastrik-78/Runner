using System.Collections;
using UnityEngine;
using Utils;
using Zenject;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private AudioSource source;
        [SerializeField] private LayerMask player;

        private Transform _target;

        [Inject]
        private void Construct(Transform target)
        {
            _target = target;
        }

        private void OnEnable()
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
            StartCoroutine(LifeTime());
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, speed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!player.Contains(other.gameObject.layer))
            {
                source.Play();
                BulletDisable();
            }
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            BulletDisable();
        }
        
        private void BulletDisable()
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
        
        public class BulletFactory : PlaceholderFactory<Transform, Bullet> { }
    }
}