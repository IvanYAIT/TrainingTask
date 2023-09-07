using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        public void ReverseGravity(Rigidbody2D playerRb) =>
            playerRb.gravityScale = -1;

        public void NormalizeGravity(Rigidbody2D playerRb) =>
            playerRb.gravityScale = 1;
    }
}