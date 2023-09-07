using Core;
using Level.Bonus;
using UnityEngine;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private LayerMask deathLayerMask;
        [SerializeField] private LayerMask bonusLayerMask;
        private int deathLayer;
        private int bonusLayer;

        void Start()
        {
            deathLayer = (int)Mathf.Log(deathLayerMask,2);
            bonusLayer = (int)Mathf.Log(bonusLayerMask, 2);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == deathLayer)
                Game.OnGameEnd?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == bonusLayer)
            {
                collision.gameObject.SetActive(false);
                BonusCollector.OnBonusCollect?.Invoke();
            }
        }

    }
}