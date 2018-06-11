using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    private const float LOOK_SMOOTH = 0.09f;
    private readonly Vector3 OFFSET_FROM_TARGET = new Vector3(0f, 6f, -17f);

    private Player _player = null;
    float _rotateVel = 0f;

    [Inject]
    public void Construct(Player player)
    { 
        _player = player;
    }

    public void LateUpdate()
    {
        MoveToTarget();
        LookAtTarget();

    }

    private void LookAtTarget()
    {
        if (_player.IsRotation)
        {
            float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _player.Transform.eulerAngles.y, ref _rotateVel, LOOK_SMOOTH);
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
        }
    }

    private void MoveToTarget()
    {
        Vector3 destination = _player.TargetRotation * OFFSET_FROM_TARGET;
        destination += _player.Position;
        transform.position = destination;
    }

}
