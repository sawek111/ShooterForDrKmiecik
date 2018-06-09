using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Settings", menuName = "Installers/Settings")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    [SerializeField] private MenuInstaller.Settings _menuSettings = null;
    [SerializeField] private GameplayInstaller.Settings _gameplaySettings = null;

    [SerializeField]  private Player.Settings _player = null;

    public override void InstallBindings()
    {
        Container.BindInstance(_menuSettings);
        Container.BindInstance(_gameplaySettings);

        Container.BindInstance(_player);
    }
}