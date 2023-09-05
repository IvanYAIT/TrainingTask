using Player;
using Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Bootstrappecr : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private GameObject levelPartPrefab;
        [SerializeField] private Transform levelPartContainer;
        [SerializeField] private KeyCode jumpKey;

        private Game _gama;
        private LevelGenerator _levelGenerator;

        void Start()
        {
            _gama = new Game();
            PlayerController playerController = new PlayerController();
            LevelPool levelPool = new LevelPool(5, levelPartPrefab, levelPartContainer);
            _levelGenerator = new LevelGenerator(levelPool);
            inputListener.Construct(playerController, jumpKey);

        }

        private void Update()
        {
            _gama.Start(jumpKey);
        }
    }
}