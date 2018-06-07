using System;
using Zenject;

public class GameplayInstaller : MonoInstaller<GameplayInstaller>
{

    [Inject] private Settings _settings = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<UnityService>().AsSingle();
    }

    [Serializable]
    public class Settings
    {
    }
}
