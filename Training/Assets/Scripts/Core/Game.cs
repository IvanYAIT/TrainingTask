using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {

        public static Action OnGameEnd;

        public Game()
        {
            Pause();
            OnGameEnd += End;
        }

        public void Start(KeyCode startKey)
        {
            if (Input.GetKeyDown(startKey))
                UnPause();
        }

        public void End() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public static void Pause() =>
            Time.timeScale = 0;

        public static void UnPause() =>
            Time.timeScale = 1;
    }
}