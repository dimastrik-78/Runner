using UnityEngine;
using Utils;

namespace LevelSystem
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private LayerMask player;

        private void OnTriggerEnter(Collider col)
        {
            if (player.Contains(col.gameObject.layer))
            {
                gameObject.SetActive(false);
            }
        }
    }
}