using UnityEngine;

namespace Level
{
    public class LevelPart : MonoBehaviour
    {
        [SerializeField] private GameObject bonus;
        [SerializeField] private Transform obstacleContainer;
        [SerializeField] private LayerMask deathLayerMask;
        private int _deathLayer;

        void Start()
        {
            _deathLayer = (int)Mathf.Log(deathLayerMask, 2);
        }

        private void Update()
        {
            transform.position -= new Vector3(3*Time.deltaTime, 0, 0);
        }

        public void GenerateObstcle()
        {
            if (obstacleContainer.childCount > 0)
                obstacleContainer.GetChild(Random.Range(0, obstacleContainer.childCount)).gameObject.SetActive(true);
        }

        public void GenerateBonus()
        {
            if (Random.Range(0, 2) == 1)
                bonus.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _deathLayer)
            {
                bonus.SetActive(false);
                for (int i = 0; i < obstacleContainer.childCount; i++)
                {
                    obstacleContainer.GetChild(i).gameObject.SetActive(false);
                }
                transform.parent = transform.parent.parent;
                gameObject.SetActive(false);
            }
        }
    }
}