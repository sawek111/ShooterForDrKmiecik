using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private EnemyBehavior _behevior = null;

    [Inject]
    public void Construct(EnemyBehavior behevior)
    {
        _behevior = behevior;
    }

    public void UpdateBehavior()
    {
        _behevior.Update();
    }



}
