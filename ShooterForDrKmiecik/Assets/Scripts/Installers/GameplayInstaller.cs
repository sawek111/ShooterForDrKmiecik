using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller>
{
    [Inject] private readonly Settings _settings = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UnityService>().AsSingle();
        Container.BindInterfacesAndSelfTo<Player>().FromSubContainerResolve().ByNewPrefab(_settings.PlayerPrefab).AsSingle().NonLazy();
    }

    [Serializable]
    public class Settings
    {
        public GameObject PlayerPrefab;
    }
}
