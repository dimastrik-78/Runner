using UnityEngine;

namespace LevelSystem
{
    public class Generation
    {
        private int _count;

        public void InstTiles(ObjectPool pool, GameObject[] objects, int countSpawn)
        {
            for (int i = 0; i < countSpawn; i++)
            {
                pool.AddTile(Object.Instantiate(objects[_count]));
                pool.TileMoving();

                _count++;
                if (_count >= objects.Length)
                {
                    _count = 0;
                }
            }
        }
    }
}
