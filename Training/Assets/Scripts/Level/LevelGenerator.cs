using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelGenerator
    {
        private const float MOVE_DISTANCE = 150;
        private LevelPool _pool;

        public LevelGenerator(LevelPool pool)
        {
            _pool = pool;
            InitLevel();
        }

        public void InitLevel()
        {
            for (int i = 0; i < _pool.Lenght; i++)
            {
                GameObject levelPart = _pool.GetFreeElement().gameObject;
                levelPart.transform.position = new Vector3(0, 0, MOVE_DISTANCE * i);
                levelPart.SetActive(true);
            }
        }

        public void Generate()
        {
            LevelPart levelPart = _pool.GetFreeElement();

            if (levelPart != null)
            {

            }
        }
    }
}