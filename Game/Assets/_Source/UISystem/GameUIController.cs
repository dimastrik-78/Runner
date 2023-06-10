using System.Collections;
using UnityEngine;

namespace UISystem
{
    public class GameUIController
    {
        private readonly GameUIView _view;
        
        private int _score;

        public GameUIController(GameUIView view)
        {
            _view = view;
        }
            
        public IEnumerator AddScore()
        {
            while (true)
            {
                _score++;
                _view.UpdateScore(_score);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}