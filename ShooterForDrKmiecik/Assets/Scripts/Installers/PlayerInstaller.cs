using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller<PlayerInstaller>
{
    [SerializeField] private Settings _settings = null;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerCharacterController>().AsSingle().WithArguments(_settings.Animator, _settings.Rigidbody, _settings.Transform).NonLazy();

        Container.BindInterfacesAndSelfTo<Shooter>().AsSingle().WithArguments(_settings.GunTransform, _settings.Player, _settings.Animator, ShooterType.Player).NonLazy();
    }

    [Serializable]
    public class Settings
    {
        public Animator Animator;
        public Rigidbody Rigidbody;
        public Transform Transform;

        public Transform GunTransform;
        public Player Player;
    }
}