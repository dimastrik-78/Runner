using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<GameObject> _tilePool = new();
    private Transform _spawnPoint;
    //private Generation _generation;
    private System.Random _random = new();

    public ObjectPool(Transform spawnPoint) 
    {
        _spawnPoint = spawnPoint;
    }

    public void TileMoving()
    {
        GameObject tile = CheckPool();
        tile.transform.position = _spawnPoint.position;
        _spawnPoint.position = new Vector3(0, 0, _spawnPoint.position.z + tile.transform.localScale.z * 2);
    }

    public void AddTile(GameObject tile)
    {
        _tilePool.Add(tile);
    }

    private GameObject CheckPool()
    {
        for (int i = 0; i < _tilePool.Count; i++)
        {
            if (_tilePool[i].activeSelf)
            {
                return _tilePool[i];
            }
        }
        return Object.Instantiate(_tilePool[_random.Next(0, _tilePool.Count)]);
    }
}
