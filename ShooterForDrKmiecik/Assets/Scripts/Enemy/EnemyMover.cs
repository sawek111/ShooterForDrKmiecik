
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMover
{
    [Inject] private Settings _settings = null;

    private Transform _transform = null;
    private Rigidbody _rigidbody = null;

    private PathFinder _pathFinder = null;

    private Vector3 _targetPosition = Vector3.zero;

    private List<GridNode> _path = new List<GridNode>();

    [Inject]
    public EnemyMover(Transform basicTransform, Rigidbody rigidbody, PathFinder pathFinder)
    {
        _rigidbody = rigidbody;
        _transform = basicTransform;

        _pathFinder = pathFinder;
    }

    public void MoveTo(Vector3 newPosition)
    {
        if ((newPosition - _targetPosition).sqrMagnitude > _settings.TargetChangeAvailableOffset)
        {
            _targetPosition = newPosition;
            _path = _pathFinder.FindPath(_transform.position, newPosition);
        }

        if ((_path[0].WorldPos - _transform.position).sqrMagnitude <= _settings.DistanceToTargetAvailableOffset)
        {
            _path.RemoveAt(0);
        }

        _transform.LookAt(_path[0].WorldPos);
        _rigidbody.velocity = _transform.forward * _settings.RunSpeed;
    }

    public void EscapeFrom(Vector3 avoidingPosition)
    {
        Vector3 escapeDirection = Vector3.ClampMagnitude(_transform.position - avoidingPosition, _settings.EscapeMaxDistance);

        _pathFinder.FindPath(_transform.position, escapeDirection);

        //TODO end mech EscapeFrom

    }

    public class Settings
    {
        public float DistanceToTargetAvailableOffset;
        public float TargetChangeAvailableOffset;

        public float RunSpeed;

        public float EscapeMaxDistance;
    }
}
