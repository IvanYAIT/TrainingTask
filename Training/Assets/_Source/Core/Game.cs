using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core
{
    public class Game
    {

        public static Action OnGameEnd;

        private GameView _gameView;

        [Inject]
        public Game(GameView gameView)
        {
            _gameView = gameView;
            Pause();
            OnGameEnd += End;
        }

        public void Start()
        {
            _gameView.StartText.text = $"Press SPACE to start";
            if (Input.GetAxis("Jump") > 0 || Input.GetKey(KeyCode.Space))
            {
                _gameView.StartText.text = "";
                UnPause();
            }
        }

        public void End() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public static void Pause() =>
            Time.timeScale = 0;

        public static void UnPause() =>
            Time.timeScale = 1;
    }
}