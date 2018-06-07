using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Settings", menuName = "Installers/Settings")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    private MenuInstaller.Settings _menuSettings = null;
    private GameplayInstaller.Settings _gameplaySettings = null;


    public override void InstallBindings()
    {
        Container.BindInstance(_menuSettings);
        Container.BindInstance(_gameplaySettings);
    }
}