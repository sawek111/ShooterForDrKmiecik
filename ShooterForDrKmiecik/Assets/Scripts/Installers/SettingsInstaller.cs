using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Settings", menuName = "Installers/Settings")]
public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
{
    [SerializeField] private MenuInstaller.Settings _menu = null;
    [SerializeField] private GameplayInstaller.Settings _gameplay = null;

    [SerializeField] private PlayerHealth.Settings _playerHealth = null;
    [SerializeField] private PlayerCharacterController.Settings _characterController = null;

    [SerializeField] private EnemyHealth.Settings _enemyHealth = null;
    [SerializeField] private EnemyAnimatorController.Settings _enemyAnimator = null;
    [SerializeField] private EnemyMover.Settings _enemyMover = null;
    [SerializeField] private EnemyDistanceSkills.Settings _enemyDistanceSkills = null;

    [SerializeField] private Shooter.Settings _shooter = null;

    public override void InstallBindings()
    {
        Container.BindInstance(_menu);
        Container.BindInstance(_gameplay);

        Container.BindInstance(_playerHealth);
        Container.BindInstance(_characterController);

        Container.BindInstance(_enemyHealth);
        Container.BindInstance(_enemyAnimator);
        Container.BindInstance(_enemyMover);
        Container.BindInstance(_enemyDistanceSkills);

        Container.BindInstance(_shooter);
    }
}