using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation
{
    private int count;

    public Generation() { }

    public void InstTiles(ObjectPool pool, GameObject[] objects, int countSpawn)
    {
        for (int i = 0; i < countSpawn; i++)
        {
            pool.AddTile(Object.Instantiate(objects[count]));
            pool.TileMoving();

            count++;
            if (count >= objects.Length)
            {
                count = 0;
            }
        }
    }
}
