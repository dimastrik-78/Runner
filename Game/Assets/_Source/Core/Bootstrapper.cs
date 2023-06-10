using LevelSystem;
using UISystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Distance distance;
        [SerializeField] private GameObject[] tilePrefabs;
        [SerializeField] private int countSpawn;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameUIView gameUIView;

        private Generation _generation;
        private ObjectPool _pool;

        void Awake()
        {
            // _generation = new Generation();
            // ObjectPool pool = new ObjectPool(spawnPoint);
            _generation.InstTiles(_pool, tilePrefabs, countSpawn);
            distance.SetPool(_pool);

            StartCoroutine(new GameUIController(gameUIView).AddScore());
        }
    }
}
