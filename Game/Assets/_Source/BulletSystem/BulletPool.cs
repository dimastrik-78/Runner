using System.Collections.Generic;
using Interface;
using UnityEngine;
using Zenject;

namespace BulletSystem
{
    public class BulletPool : IObjectPool
    {
        private readonly GameObject _prefabBullet;
        private readonly List<GameObject> _bulletPool = new();
        private readonly Transform _spawnPoint;

        [Inject]
        public BulletPool(GameObject prefabBullet, Transform spawnPoint)
        {
            _prefabBullet = prefabBullet;
            _spawnPoint = spawnPoint;
        }

        public void ObjectMoving()
        {
            GameObject tile = CheckPool();
            tile.transform.position = _spawnPoint.position;
            tile.SetActive(true);
        }

        public void AddObject(GameObject gameObject)
        {
            _bulletPool.Add(gameObject);
        }

        private GameObject CheckPool()
        {
            for (int i = 0; i < _bulletPool.Count; i++)
            {
                if (!_bulletPool[i].activeSelf)
                {
                    return _bulletPool[i];
                }
            }
            
            _bulletPool.Add(Object.Instantiate(_prefabBullet));
            return _bulletPool[^1];
        }
    }
}