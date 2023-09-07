using UnityEngine;

namespace Player
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D playerRb;

        public Rigidbody2D PlayerRb => playerRb;
    }
}