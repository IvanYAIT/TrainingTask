using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {

        public static Action OnGameEnd;

        private GameView _gameView;

        public Game(GameView gameView)
        {
            _gameView = gameView;
            Pause();
            OnGameEnd += End;
        }

        public void Start(KeyCode startKey)
        {
            _gameView.StartText.text = $"Press {startKey} to start";
            if (Input.GetKeyDown(startKey))
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