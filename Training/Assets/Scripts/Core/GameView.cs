using System.Collections;
using System.Collections.Generic;
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