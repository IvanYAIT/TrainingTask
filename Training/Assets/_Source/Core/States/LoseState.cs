using UnityEngine.SceneManagement;

namespace Core
{
    public class LoseState : AState
    {
        public override void Enter()=>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}