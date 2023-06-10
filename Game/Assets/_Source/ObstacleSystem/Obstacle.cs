using System;
using UnityEngine;
using Utils;

namespace ObstacleSystem
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private GameObject ruinObstacle;
        [SerializeField] private LayerMask bullet;

        private void OnTriggerEnter(Collider other)
        {
            if (bullet.Contains(other.gameObject.layer))
            {
                gameObject.SetActive(false);
                ruinObstacle.SetActive(true);
                ruinObstacle.transform.parent = null;
            }
        }
    }
}