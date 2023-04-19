using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;
    [SerializeField] private int countSpawn;
    [SerializeField] private Transform spawnPoint;

    private Generation _generation;

    void Awake()
    {
        _generation = new Generation();
        ObjectPool pool = new ObjectPool(spawnPoint);
        _generation.InstTiles(pool, tilePrefabs, countSpawn);
    }
}
