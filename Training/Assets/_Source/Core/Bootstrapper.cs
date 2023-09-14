using Player;
using Level;
using UnityEngine;
using Level.Bonus;
using VContainer;

namespace Core
{
    public class Bootstrappecr : MonoBehaviour
    {
        private bool isGameStarted=false;
        private Game _gama;
        private LevelGenerator _levelGenerator;

        [Inject]
        public void Construct(Game game, LevelGenerator levelGenerator)
        {
            _gama = game;
            _levelGenerator = levelGenerator;
        }

        private void Update()
        {
            if (!isGameStarted)
            {
                _gama.Start();
                if (Time.timeScale == 1)
                    isGameStarted = true;
            }


            _levelGenerator.Generate();
        }
    }
}