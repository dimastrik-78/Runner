using System.Collections.Generic;
using Interface;
using UnityEngine;
using Zenject;

namespace LevelSystem
{
    public class TilePool : IObjectPool
    {
        private const float TRAVEL_DISTANCE = 10;
        
        private readonly List<GameObject> _tilePool = new();
        private readonly Transform _spawnPoint;
        private readonly System.Random _random = new();

        [Inject]
        public TilePool(Transform spawnPoint) 
        {
            _spawnPoint = spawnPoint;
        }

        public void ObjectMoving()
        {
            GameObject tile = CheckPool();
            tile.transform.position = _spawnPoint.position;
            _spawnPoint.position = new Vector3(0, 0, _spawnPoint.position.z + tile.transform.localScale.z * TRAVEL_DISTANCE);
            tile.SetActive(true);
        }

        public void AddObject(GameObject bullet)
        {
            _tilePool.Add(bullet);
        }

        private GameObject CheckPool()
        {
            List<GameObject> tiles = new();

            for (int i = 0; i < _tilePool.Count; i++)
            {
                if (!_tilePool[i].activeSelf)
                {
                    tiles.Add(_tilePool[i]);
                }
            }

            if (tiles.Count != 0)
            {
                return SelectTile(tiles);
            }
            
            return Object.Instantiate(_tilePool[_random.Next(0, _tilePool.Count)]);
        }

        private GameObject SelectTile(List<GameObject> tiles) 
            => tiles[_random.Next(0, tiles.Count)];
    }
}
