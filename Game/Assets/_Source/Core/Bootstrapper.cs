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
        [SerializeField] private int countTileSpawn;
        [SerializeField] private int countBulletSpawn;
        [SerializeField] private Transform bulletParent;

        [Inject] private Generation _generation;
        [Inject] private TilePool _tilePool;
        [Inject] private GameUIController _gameUIController;
        [Inject] private BulletSpawner _spawner;

        void Awake()
        {
            _generation.InstTiles(_tilePool, tilePrefabs, countTileSpawn);
            _spawner.Spawn(bulletParent, countBulletSpawn);

            StartCoroutine(_gameUIController.AddScore());
        }
    }
}
