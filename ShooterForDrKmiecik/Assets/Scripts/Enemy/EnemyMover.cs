
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyMover
{
    [Inject] private Settings _settings = null;

    private readonly Transform _transform = null;
    private readonly Rigidbody _rigidbody = null;

    private readonly PathFinder _pathFinder = null;

    private TargetType _targetType = TargetType.NONE;

    private Vector3 _targetPosition = Vector3.zero;

    private List<GridNode> _path = new List<GridNode>();

    [Inject]
    public EnemyMover(Transform basicTransform, Rigidbody rigidbody, PathFinder pathFinder)
    {
        _rigidbody = rigidbody;
        _transform = basicTransform;

        _pathFinder = pathFinder;
    }

    public bool IsInTarget
    {
        get { return (_transform.position - _targetPosition).magnitude < _settings.DistanceToTargetAvailableOffset; }
    }

    public TargetType TargetType
    {
        get { return _targetType;  }
    }

    public void MoveToTarget()
    {
        if(_path.Count == 0)
        {
            return;
        }

        if ((_path[0].WorldPos - _transform.position).magnitude <= _settings.DistanceToPathElementtAvailableOffset)
        {
            _path.RemoveAt(0);
            if (_path.Count == 0)
            {
                return;
            }
        }

        Vector3 dest = _path[0].WorldPos;
        dest.y = 0.4f;
        _transform.LookAt(dest);
        _rigidbody.velocity = _transform.forward * _settings.RunSpeed;
    }

    public void SetNewTarget(Vector3 newPosition, TargetType targetType)
    {
        _path = _pathFinder.FindPath(_transform.position, newPosition);
        _targetPosition = (_path.Count > 0) ? _path[_path.Count - 1].WorldPos : newPosition;
        _targetType = targetType;
    }

    public void RemoveTarget()
    {
        _targetType = TargetType.NONE;
    }

    public Vector3 PrepareEscapePosition(Vector3 playerPos)
    {
        Vector3 escapeDirection = Vector3.ClampMagnitude(_transform.position - playerPos, _settings.EscapeMaxDistance);
        Vector3 simpleEscapePos = _transform.position + escapeDirection;

        Vector2 randFactors = (UnityEngine.Random.insideUnitCircle * _settings.EscapeMaxDistance);
        Vector3 rand = new Vector3(randFactors.x, 0f, randFactors.y);
        
        return simpleEscapePos + rand;
    }

    [Serializable]
    public class Settings
    {
        public float DistanceToPathElementtAvailableOffset;
        public float DistanceToTargetAvailableOffset;
        public float TargetChangeAvailableOffset;

        public float RunSpeed;

        public float EscapeMaxDistance;
    }
}
