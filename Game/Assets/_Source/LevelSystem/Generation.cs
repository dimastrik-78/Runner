using BulletSystem;
using UnityEngine;

namespace LevelSystem
{
    public class Generation
    {
        private int _count;

        public void InstTiles(TilePool pool, GameObject[] objects, int countSpawn)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                pool.AddObject(Object.Instantiate(objects[_count]));
                pool.ObjectMoving();

                _count++;
                if (_count >= objects.Length)
                {
                    _count = 0;
                }
            }
        }

        public void InstBullets(BulletPool pool, GameObject prefab, int countSpawn)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                pool.AddObject(Object.Instantiate(prefab));
            }
        }
    }
}
