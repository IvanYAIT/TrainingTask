using System;

namespace Level.Bonus
{
    public class BonusCollector
    {
        public static Action OnBonusCollect;

        private BonusView _view;
        private int bonuses = 0;

        public BonusCollector(BonusView view)
        {
            _view = view;
            _view.BonusText.text = $"{bonuses}";
            OnBonusCollect += CollectBonus;
        }

        private void CollectBonus()
        {
            bonuses++;
            _view.BonusText.text = $"{bonuses}";
        }

    }
}