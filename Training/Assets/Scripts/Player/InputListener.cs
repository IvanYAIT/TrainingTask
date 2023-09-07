using UnityEngine;

namespace Player
{
    public class InputListener : MonoBehaviour
    {
        private KeyCode _jumpKey;
        private PlayerController _playerController; 
        private PlayerData _playerData;

        public void Construct(PlayerController playerController, KeyCode jumpKey, PlayerData playerData)
        {
            _playerData = playerData;
            _playerController = playerController;
            _jumpKey = jumpKey;
        }

        void Update()
        {
            if (Input.GetKey(_jumpKey) || Input.GetAxis("Jump") > 0)
                _playerController.ReverseGravity(_playerData.PlayerRb);
            else
                _playerController.NormalizeGravity(_playerData.PlayerRb);
        }
    }
}