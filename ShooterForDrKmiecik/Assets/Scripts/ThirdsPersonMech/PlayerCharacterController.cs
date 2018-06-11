using System;
using UnityEngine;
using Zenject;

public class PlayerCharacterController : IInitializable, IFixedTickable, ITickable
{
    [Inject] private readonly Settings _settings;

    private readonly UnityService _unityService = null;
    private readonly PlayerHealth _playerHealth = null;
    private readonly Shooter _shooter = null;


    private readonly Rigidbody _rigid = null;
    private readonly Animator _animator = null;
    private readonly Transform _transform = null;

    private Quaternion _targetRot;

    private float _forInput = 0f;
    private float _turnInput = 0f;

    private AnimationState _action = AnimationState.DIE;


    [Inject]
    public PlayerCharacterController(Animator animator, Rigidbody rigidbody, Transform targetTransform, UnityService unityService, PlayerHealth playerHealth, Shooter shooter)
    {
        _unityService = unityService;
        _playerHealth = playerHealth;
        _shooter = shooter;

        _animator = animator;
        _rigid = rigidbody;
        _transform = targetTransform;
    }

    public void Initialize ()
    {
        _targetRot = _transform.rotation;
    }

    public void Tick()
    {
        _action = GetInput();
    }

    public void FixedTick()
    {
        ApplyAction(_action);
    }

    public Quaternion TargetRotation
    {
        get { return _targetRot; }
    }

    public bool IsRotation
    {
        get { return Mathf.Abs(_turnInput) > _settings.InputDelay; }
    }

    private void ApplyAction(AnimationState currentState)
    {
        _animator.SetInteger(_settings.StateString, (int)currentState);

        if (currentState == AnimationState.RUN)
        {
            Run();
            Turn();
        }
        else if(currentState == AnimationState.SHOT)
        {
            _shooter.Shoot();
        }
    }


    private void Turn()
    {
        if (Mathf.Abs(_turnInput) > _settings.InputDelay)
        {
            _targetRot *= Quaternion.AngleAxis(_settings.RotateSpeed * _turnInput * Time.deltaTime, Vector3.up);
            _transform.rotation = _targetRot;
        }

        _rigid.angularVelocity = Vector3.zero;
    }

    private void Run()
    {

        if(Mathf.Abs(_forInput) > _settings.InputDelay)
        {
            _rigid.velocity = _transform.forward * _forInput * _settings.ForwardSpeed;
            return;
        }
        _rigid.velocity = Vector3.zero;
    }

    private AnimationState GetInput()
    {
        if (_playerHealth.Dead)
        {
            return AnimationState.DIE;
        }
        if (_unityService.IsLeftMouseButtonUp)
        {
            return AnimationState.SHOT;
        }
        if (_unityService.GetKeyUp(KeyCode.Space))
        {
            return AnimationState.JUMP;
        }
        if (_unityService.GetAxis(Axis.HORIZONTAL) != 0 || _unityService.GetAxis(Axis.VERTICAL) != 0)
        {
            _forInput = _unityService.GetAxis(Axis.VERTICAL);
            _turnInput = _unityService.GetAxis(Axis.HORIZONTAL);
            return AnimationState.RUN;
        }

        return AnimationState.IDLE;
    }

    [Serializable]
    public class Settings
    {
        public float ForwardSpeed;
        public float RotateSpeed;

        public float InputDelay;
        public string StateString;
    }
}
