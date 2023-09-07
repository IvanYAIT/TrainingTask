using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRb;
        private KeyCode _jumpKey;

        private PlayerController _playerController; 

        public void Construct(PlayerController playerController, KeyCode jumpKey)
        {
            _playerController = playerController;
            _jumpKey = jumpKey;
        }

        void Update()
        {
            if (Input.GetKey(_jumpKey) || Input.GetAxis("Jump") > 0)
                _playerController.ReverseGravity(playerRb);
            else
                _playerController.NormalizeGravity(playerRb);
        }
    }
}