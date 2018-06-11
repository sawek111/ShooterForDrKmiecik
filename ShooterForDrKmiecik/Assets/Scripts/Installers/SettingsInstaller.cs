using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Settings", menuName = "Installers/Settings")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    [SerializeField] private MenuInstaller.Settings _menuSettings = null;
    [SerializeField] private GameplayInstaller.Settings _gameplaySettings = null;

    [SerializeField]  private Player.Settings _player = null;

    [SerializeField] private EnemyHealth.Settings _enemyHealth = null;
    [SerializeField] private EnemyAnimatorController.Settings _enemyAnimator = null;
    [SerializeField] private EnemyMover.Settings _enemyMover = null;
    [SerializeField] private EnemyDistanceSkills.Settings _enemyDistanceSkills = null;



    public override void InstallBindings()
    {
        Container.BindInstance(_menuSettings);
        Container.BindInstance(_gameplaySettings);

        Container.BindInstance(_player);

        Container.BindInstance(_enemyHealth);
        Container.BindInstance(_enemyAnimator);
        Container.BindInstance(_enemyMover);
        Container.BindInstance(_enemyDistanceSkills);
    }
}