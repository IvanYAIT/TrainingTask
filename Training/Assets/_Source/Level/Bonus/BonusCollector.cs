using VContainer;

namespace Level.Bonus
{
    public class BonusCollector
    {
        private BonusView _view;
        private int bonuses = 0;

        [Inject]
        public BonusCollector(BonusView view)
        {
            _view = view;
            _view.ChangeText($"{bonuses}");
        }

        public void CollectBonus()
        {
            bonuses++;
            _view.ChangeText($"{bonuses}");
        }

    }
}