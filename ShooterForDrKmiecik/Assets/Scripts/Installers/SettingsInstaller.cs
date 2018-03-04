using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Settings", menuName = "Installers/Settings")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    public MenuInstaller.Settings _menuSettings = null;

    public override void InstallBindings()
    {
        Container.BindInstance(_menuSettings);
        return;
    }
}