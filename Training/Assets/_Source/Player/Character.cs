using Core;
using Level.Bonus;
using UnityEngine;
using VContainer;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private LayerMask deathLayerMask;
        [SerializeField] private LayerMask bonusLayerMask;

        private int deathLayer;
        private int bonusLayer;
        private IStateMachine _stateMachine;
        private BonusCollector _bonusCollector;

        [Inject]
        public void Construct(IStateMachine stateMachine, BonusCollector bonusCollector)
        {
            _stateMachine = stateMachine;
            _bonusCollector = bonusCollector;
        }

        void Start()
        {
            deathLayer = (int)Mathf.Log(deathLayerMask,2);
            bonusLayer = (int)Mathf.Log(bonusLayerMask, 2);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == deathLayer)
                _stateMachine.ChangeState<LoseState>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == bonusLayer)
            {
                collision.gameObject.SetActive(false);
                _bonusCollector.CollectBonus();
            }
        }

    }
}