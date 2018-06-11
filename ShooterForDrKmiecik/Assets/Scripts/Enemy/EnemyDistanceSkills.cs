using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyDistanceSkills
{
    [Inject] private Settings _settings = null;

    private Transform _transform = null;
    private Player _player = null;

    public EnemyDistanceSkills(Transform transform, Player player)
    {
        _transform = transform;
        _player = player;
    }

    public bool  CanSeePlayer()
    {
        if(Mathf.Abs((_transform.position - _player.Position).sqrMagnitude) < _settings.VisiblePlayerDistance)
        {
            RaycastHit hit;
            if(Physics.Raycast(_transform.position, _player.Position - _transform.position, out hit, _settings.VisiblePlayerDistance))
            {
                if(hit.collider.gameObject.GetComponent<Player>() != null)
                {
                    return true;
                }
            }
        }

        return false;  
    }

    public bool CanShootPlayer()
    {
        if(CanSeePlayer())
        {
            Debug.Log("Can shoot");
           return Mathf.Abs((_transform.position - _player.Position).sqrMagnitude) <= _settings.ShootingDistance;
        }

        return false;
    }

    [Serializable]
    public class Settings
    {
        public float VisiblePlayerDistance;
        public float ShootingDistance;
    }
}
