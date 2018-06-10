using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller<EnemyInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EnemyBehavior>().AsSingle().NonLazy();
    }

}
