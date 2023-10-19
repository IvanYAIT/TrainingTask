using Core;
using UnityEngine;
using VContainer;

namespace Player
{
    public class InputListener : MonoBehaviour
    {
        private PlayerController _playerController; 
        private PlayerData _playerData;
        private IStateMachine _stateMachine;
        private bool gameStarted;

        [Inject]
        public void Construct(PlayerController playerController, PlayerData playerData, IStateMachine stateMachine)
        {
            _playerData = playerData;
            _playerController = playerController;
            _stateMachine = stateMachine;
        }

        void Update()
        {
            if (Input.GetAxis("Jump") > 0 || Input.GetMouseButton(0))
                _playerController.ReverseGravity(_playerData.PlayerRb);
            else
                _playerController.NormalizeGravity(_playerData.PlayerRb);

            if(!gameStarted && Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                _stateMachine.ChangeState<GameState>();
                gameStarted = true;
            }
        }
    }
}