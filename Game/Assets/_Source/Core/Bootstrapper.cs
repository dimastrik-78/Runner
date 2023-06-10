using BulletSystem;
using LevelSystem;
using UISystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject[] tilePrefabs;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int countTileSpawn;
        [SerializeField] private int countBulletSpawn;
        
        [Inject] private Generation _generation;
        [Inject] private TilePool _tilePool;
        [Inject] private BulletPool _bulletPool;
        [Inject] private GameUIController _gameUIController;

        void Awake()
        {
            _generation.InstTiles(_tilePool, tilePrefabs, countTileSpawn);
            _generation.InstBullets(_bulletPool, bulletPrefab, countBulletSpawn);

            StartCoroutine(_gameUIController.AddScore());
        }
    }
}
