using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller>
{
    [Inject] private readonly Settings _settings = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<UnityService>().AsSingle();
        Container.BindInterfacesAndSelfTo<Player>().FromSubContainerResolve().ByNewPrefab(_settings.PlayerPrefab).AsSingle().NonLazy();

        Container.BindFactory<Enemy, Enemy.Factory>().FromComponentInNewPrefab(_settings.EnemyPrefab);
    }

    [Serializable]
    public class Settings
    {
        public GameObject PlayerPrefab;
        public GameObject EnemyPrefab;
    }
}
