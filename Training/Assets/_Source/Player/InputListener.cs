using UnityEngine;
using Zenject;

namespace Player
{
    public class InputListener : MonoBehaviour
    {
        private PlayerController _playerController; 
        private PlayerData _playerData;

        [Inject]
        public void Construct(PlayerController playerController, PlayerData playerData)
        {
            _playerData = playerData;
            _playerController = playerController;
        }

        void Update()
        {
            if (Input.GetAxis("Jump") > 0)
                _playerController.ReverseGravity(_playerData.PlayerRb);
            else
                _playerController.NormalizeGravity(_playerData.PlayerRb);
        }
    }
}