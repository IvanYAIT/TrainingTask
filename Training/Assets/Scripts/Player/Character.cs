using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private LayerMask deathLayerMask;
        private int deathLayer;

        void Start()
        {
            deathLayer = (int)Mathf.Log(deathLayerMask,2);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == deathLayer)
                Game.OnGameEnd?.Invoke();
        }

    }
}