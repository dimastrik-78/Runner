using System.Collections;
using UnityEngine;
using Zenject;

namespace UISystem
{
    public class GameUIController
    {
        private readonly GameUIView _view;
        
        private int _score;

        [Inject]
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