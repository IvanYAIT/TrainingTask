using Player;
using Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level.Bonus;

namespace Core
{
    public class Bootstrappecr : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private GameObject levelPartPrefab;
        [SerializeField] private Transform levelPartContainer;
        [SerializeField] private KeyCode jumpKey;
        [SerializeField] private BonusView bonusView;
        [SerializeField] private GameView gameView;

        private bool isGameStarted=false;
        private Game _gama;
        private LevelGenerator _levelGenerator;

        void Start()
        {
            _gama = new Game(gameView);
            PlayerController playerController = new PlayerController();
            BonusCollector bonusCollector = new BonusCollector(bonusView);
            LevelPool levelPool = new LevelPool(5, levelPartPrefab, levelPartContainer);
            _levelGenerator = new LevelGenerator(levelPool, levelPartContainer);
            inputListener.Construct(playerController, jumpKey);

        }

        private void Update()
        {
            if (!isGameStarted)
            {
                _gama.Start(jumpKey);
                if (Time.timeScale == 1)
                    isGameStarted = true;
            }


            _levelGenerator.Generate();
        }
    }
}