using System;
using System.Collections;
using UnityEngine;

namespace LevelSystem
{
    public class Distance : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        private ObjectPool _pool;

        private void Start()
        {
            StartCoroutine(Check());
        }

        private IEnumerator Check()
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);

            if (Vector3.Distance(transform.position, player.position) < 40)
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