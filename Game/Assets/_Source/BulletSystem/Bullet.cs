using System.Collections;
using UnityEngine;
using Utils;
using Zenject;

namespace BulletSystem
{
    public abstract class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        [SerializeField] private AudioSource source;
        [SerializeField] private LayerMask player;

        private void OnEnable()
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
            StartCoroutine(LifeTime());
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            BulletDisable();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!player.Contains(other.gameObject.layer))
            {
                source.Play();
                BulletDisable();
            }
        }

        private void BulletDisable()
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
        
        public abstract class BulletFactory : PlaceholderFactory<Bullet> { }
    }
}