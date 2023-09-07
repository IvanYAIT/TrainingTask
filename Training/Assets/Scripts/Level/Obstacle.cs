using UnityEngine;

namespace Level
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float lenght;
        [SerializeField] private float speed;

        private float stratY;
        private bool isGoUp = true;

        private void Start()
        {
            stratY = transform.position.y;
        }


        void Update()
        {
            Move();
        }

        private void Move()
        {
            if (transform.position.y <= stratY && !isGoUp)
            {
                if (speed < 0)
                    speed *= -1;
                isGoUp = true;
            }
            else if (transform.position.y >= stratY + lenght && isGoUp)
            {
                speed *= -1;
                isGoUp = false;
            }
            transform.position += new Vector3(0, speed * Time.deltaTime);
        }
    }
}