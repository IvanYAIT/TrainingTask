using UnityEngine;
using VContainer;

namespace Core
{
    public class PauseState : AState
    {
        private GameView _view;

        [Inject]
        public PauseState(GameView view)
        {
            _view = view;
        }

        public override void Enter()
        {
            Time.timeScale = 0;
            _view.StartText.gameObject.SetActive(true);
            _view.StartText.text = $"Press SPACE to start";
        }

        public override void Exit() => Time.timeScale = 1;
    }
}