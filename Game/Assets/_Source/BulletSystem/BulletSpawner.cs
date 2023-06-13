using UnityEngine;
using Zenject;

namespace BulletSystem
{
    public class BulletSpawner
    {
        [Inject] private Bullet.BulletFactory _factory;
        [Inject] private BulletPool _bulletPool;
        [Inject] private Transform _target;
        
        public void Spawn(Transform parent, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var bullet = _factory.Create(_target);
                bullet.transform.parent = parent;
                _bulletPool.AddObject(bullet.gameObject);
            }
        }
    }
}