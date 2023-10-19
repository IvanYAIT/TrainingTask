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
        builder.RegisterComponentInHierarchy<BonusView>();
        builder.Register<BonusCollector>(Lifetime.Singleton);

        builder.Register<PlayerController>(Lifetime.Singleton);
        builder.RegisterInstance(levelData);
        builder.RegisterComponent(levelPartContainer);
        builder.RegisterComponentInHierarchy<InputListener>();
        builder.RegisterComponentInHierarchy<Character>();
        builder.RegisterComponentInHierarchy<GameView>();
        builder.RegisterComponentInHierarchy<PlayerData>();

        builder.Register<LevelPool>(Lifetime.Singleton);
        builder.RegisterComponentInHierarchy<LevelGenerator>();

        builder.Register<AState, GameState>(Lifetime.Scoped);
        builder.Register<AState, PauseState>(Lifetime.Scoped);
        builder.Register<AState, LoseState>(Lifetime.Scoped);

        builder.Register<IStateMachine, GameStateMachine<AState>>(Lifetime.Scoped);
        builder.RegisterEntryPoint<Bootstrapper>(Lifetime.Scoped);
    }
}
