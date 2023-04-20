using LevelSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Distance distance;
        [SerializeField] private GameObject[] tilePrefabs;
        [SerializeField] private int countSpawn;
        [SerializeField] private Transform spawnPoint;

        private Generation _generation;

        void Awake()
        {
            _generation = new Generation();
            ObjectPool pool = new ObjectPool(spawnPoint);
            _generation.InstTiles(pool, tilePrefabs, countSpawn);
            distance.SetPool(pool);
        }
    }
}
