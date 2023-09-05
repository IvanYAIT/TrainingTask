using UnityEngine;
using TMPro;

namespace Level.Bonus
{
    public class BonusView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI bonusText;

        public TextMeshProUGUI BonusText => bonusText;
    }
}