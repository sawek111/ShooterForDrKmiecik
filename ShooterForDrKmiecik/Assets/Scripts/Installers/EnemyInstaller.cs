using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller<EnemyInstaller>
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EnemyBehavior>().AsSingle().WithArguments(_settings.Enemy).NonLazy();
        Container.BindInterfacesAndSelfTo<EnemyHealth>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EnemyAnimatorController>().AsSingle().WithArguments(_settings.Animator).NonLazy();
        Container.BindInterfacesAndSelfTo<EnemyDistanceSkills>().AsSingle().WithArguments(_settings.Transform).NonLazy();

        Container.BindInterfacesAndSelfTo<Shooter>().AsSingle().WithArguments(_settings.GunTransform, _settings.Enemy, _settings.Animator, ShooterType.Enemy).NonLazy();

        Container.Bind<PathFinder>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EnemyMover>().AsSingle().WithArguments(_settings.Transform, _settings.Rigidbody).NonLazy();

    }

    [Serializable]
    public class Settings
    {
        public Animator Animator;
        public Rigidbody Rigidbody;
        public Transform Transform;
        public Enemy Enemy;
        public Transform GunTransform;
    }
}
