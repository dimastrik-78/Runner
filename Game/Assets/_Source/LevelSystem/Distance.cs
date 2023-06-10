using System.Collections;
using UnityEngine;

namespace LevelSystem
{
    public class Distance : MonoBehaviour
    {
        [SerializeField] private Transform player;

        private const float DISTANCE = 40f;
        
        private ObjectPool _pool;

        private void Start()
        {
            StartCoroutine(Check());
        }

        private IEnumerator Check()
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);

            if (Vector3.Distance(transform.position, player.position) < DISTANCE)
            {
                _pool.TileMoving();
            }

            StartCoroutine(Check());
        }

        public void SetPool(ObjectPool pool)
        {
            _pool = pool;
        }
    }
}