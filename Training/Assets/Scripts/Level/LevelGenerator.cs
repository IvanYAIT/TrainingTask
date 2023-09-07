using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    public class LevelGenerator
    {
        private const float MOVE_DISTANCE = 18;
        private LevelPool _pool;
        private Transform _levelPartContainer;

        public LevelGenerator(LevelPool pool, Transform levelPartContainer)
        {
            _pool = pool;
            _levelPartContainer = levelPartContainer;
            InitLevel();
        }

        public void InitLevel()
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject levelPart = _pool.GetFreeElement().gameObject;
                levelPart.transform.position = new Vector3(MOVE_DISTANCE * i, 0);
                levelPart.SetActive(true);
                levelPart.transform.parent = _levelPartContainer;
            }
        }

        public void Generate()
        {
            LevelPart levelPart = _pool.GetFreeElement();

            if (levelPart != null)
            {
                float lastPartPositionX = _levelPartContainer.GetChild(_levelPartContainer.childCount-1).transform.position.x;
                levelPart.gameObject.transform.position = new Vector3(MOVE_DISTANCE + lastPartPositionX, 0);
                levelPart.gameObject.SetActive(true);
                levelPart.gameObject.transform.parent = _levelPartContainer;
                levelPart.GenerateBonus();
                levelPart.GenerateObstcle();
            }
        }
    }
}