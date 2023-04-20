using UnityEngine;
using Utils;

namespace LevelSystem
{
    public class TileDisable : MonoBehaviour
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