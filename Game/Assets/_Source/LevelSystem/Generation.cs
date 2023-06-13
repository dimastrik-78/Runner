using UnityEngine;

namespace LevelSystem
{
    public class Generation
    {
        public void InstTiles(TilePool pool, GameObject[] objects, int countSpawn)
        {
            int count = 0;
            for (int i = 0; i < countSpawn; i++)
            {
                pool.AddObject(Object.Instantiate(objects[count]));
                pool.ObjectMoving();

                count++;
                if (count >= objects.Length)
                {
                    count = 0;
                }
            }
        }
    }
}