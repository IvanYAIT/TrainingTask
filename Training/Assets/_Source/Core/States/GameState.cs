using UnityEngine;
using VContainer;

namespace Core
{
    public class GameState : AState
    {
        private GameView _view;

        [Inject]
        public GameState(GameView view)
        {
            _view = view;
        }

        public override void Enter()
        {
            Time.timeScale = 1;
            _view.StartText.gameObject.SetActive(false);
        }

        public override void Exit() => Time.timeScale = 0;
    }
}