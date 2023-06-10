using TMPro;
using UnityEngine;

namespace UISystem
{
    public class GameUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        
        public void UpdateScore(int score)
        {
            text.text = score.ToString();
        }
    }
}