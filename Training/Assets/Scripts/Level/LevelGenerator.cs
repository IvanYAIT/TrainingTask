using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelGenerator
    {
        private LevelPool _pool;

        public LevelGenerator(LevelPool pool)
        {
            _pool = pool;
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