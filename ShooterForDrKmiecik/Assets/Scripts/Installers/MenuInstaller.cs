using System;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller<MenuInstaller>
{
    [Inject] private Settings _settings = null;

    public override void InstallBindings()
    {
        Container.Bind<MenuPanel>().FromNewComponentOnNewPrefab(_settings.MenuPanelPrefab).AsSingle().NonLazy();
        return;
    }

    [Serializable]
    public class Settings
    {
        public GameObject MenuPanelPrefab;
    }
}