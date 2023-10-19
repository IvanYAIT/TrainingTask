using Level;
using Level.Bonus;
using Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private LevelData levelData;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private BonusView bonusView;
        [SerializeField] private GameView gameView;
        [SerializeField] private PlayerData playerData;
        [SerializeField] private Transform levelPartContainer;


        public override void InstallBindings()
        {
            Container.Bind<PlayerController>().AsSingle().NonLazy();
            Container.Bind<Transform>().FromInstance(levelPartContainer).AsSingle().NonLazy();
            Container.Bind<LevelData>().FromInstance(levelData).AsSingle().NonLazy();
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle().NonLazy();
            Container.Bind<BonusView>().FromInstance(bonusView).AsSingle().NonLazy();
            Container.Bind<GameView>().FromInstance(gameView).AsSingle().NonLazy();
            Container.Bind<PlayerData>().FromInstance(playerData).AsSingle().NonLazy();

            Container.Bind<BonusCollector>().AsSingle().NonLazy();
            Container.Bind<LevelPool>().AsSingle().NonLazy();
            Container.Bind<LevelGenerator>().AsSingle().NonLazy();

        }
    }
}