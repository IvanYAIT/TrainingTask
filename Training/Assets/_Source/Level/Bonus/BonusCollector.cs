using System;
using VContainer;

namespace Level.Bonus
{
    public class BonusCollector
    {
        public static Action OnBonusCollect;

        private BonusView _view;
        private int bonuses = 0;

        [Inject]
        public BonusCollector(BonusView view)
        {
            _view = view;
            _view.ChangeText($"{bonuses}");
            OnBonusCollect += CollectBonus;
        }

        private void CollectBonus()
        {
            bonuses++;
            _view.ChangeText($"{bonuses}");
        }

    }
}