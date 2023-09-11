using UnityEngine;
using TMPro;

namespace Core
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI startText;

        public TextMeshProUGUI StartText => startText;
    }
}