using Core;
using Level.Bonus;
using Level;
using Player;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private Transform levelPartContainer;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<PlayerController>(Lifetime.Singleton);
        builder.RegisterInstance(levelData);
        builder.RegisterComponent(levelPartContainer);
        builder.RegisterComponentInHierarchy<InputListener>();
        builder.RegisterComponentInHierarchy<BonusView>();
        builder.RegisterComponentInHierarchy<GameView>();
        builder.RegisterComponentInHierarchy<PlayerData>();

        builder.Register<BonusCollector>(Lifetime.Singleton);
        builder.Register<LevelPool>(Lifetime.Singleton);
        builder.Register<Game>(Lifetime.Singleton);
        builder.Register<LevelGenerator>(Lifetime.Singleton);
    }
}
