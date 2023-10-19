using UnityEngine;
using VContainer;

namespace Level
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float MOVE_DISTANCE = 18;
        private const int AMOUNT_OF_INIT_PARTS = 2;
        private LevelPool _pool;
        private Transform _levelPartContainer;

        [Inject]
        public void Construct(LevelPool pool, Transform levelPartContainer)
        {
            _pool = pool;
            _levelPartContainer = levelPartContainer;
            InitLevel();
        }

        private void Update()
        {
            LevelPart levelPart = _pool.GetFreeElement();

            if (levelPart != null)
            {
                float lastPartPositionX = _levelPartContainer.GetChild(_levelPartContainer.childCount - 1).transform.position.x;
                levelPart.gameObject.transform.position = new Vector3(MOVE_DISTANCE + lastPartPositionX, 0);
                levelPart.gameObject.SetActive(true);
                levelPart.gameObject.transform.parent = _levelPartContainer;
                levelPart.GenerateBonus();
                levelPart.GenerateObstcle();
            }
        }

        public void InitLevel()
        {
            for (int i = 0; i < AMOUNT_OF_INIT_PARTS; i++)
            {
                GameObject levelPart = _pool.GetFreeElement().gameObject;
                levelPart.transform.position = new Vector3(MOVE_DISTANCE * i, 0);
                levelPart.SetActive(true);
                levelPart.transform.parent = _levelPartContainer;
            }
        }
    }
}