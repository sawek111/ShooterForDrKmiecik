using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterController : MonoBehaviour
{
    private const string STATE = "State";

    private const float FORWARD_SPEED = 10f;
    private const float ROTATE_SPEED = 100f;
    private const float JUMP_FACTOR = 100f;

    private const float INPUT_DELAY = 0.1f;

    private Rigidbody _rigid = null;
    private Animator _animator = null;

    private Quaternion _targetRot;

    private float _forInput = 0f;
    private float _turnInput = 0f;

    private AnimationState _action = AnimationState.DIE;

    private UnityService _unityService = null;
    private Player _player;

    [Inject]
    public void Construct(UnityService unityService, Player player)
    {
        _unityService = unityService;
        _player = player;
    }

    public void Start ()
    {
        _targetRot = transform.rotation;
        _animator = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody>();
    }

    public Quaternion TargetRotation
    {
        get { return _targetRot; }
    }

    public bool IsRotation
    {
        get { return Mathf.Abs(_turnInput) > INPUT_DELAY; }
    }

    // Update is called once per frame
    public void Update ()
    {
        _action  = GetInput();
    }

    public void FixedUpdate()
    {
        ApplyAction(_action);
    }

    private void ApplyAction(AnimationState currentState)
    {
        if (currentState == AnimationState.RUN)
        {
            Run();
            Turn();
        }

        _animator.SetInteger(STATE, (int)currentState);
    }


    private void Turn()
    {
        if (Mathf.Abs(_turnInput) > INPUT_DELAY)
        {
            _targetRot *= Quaternion.AngleAxis(ROTATE_SPEED * _turnInput * Time.deltaTime, Vector3.up);
            transform.rotation = _targetRot;
        }

        _rigid.angularVelocity = Vector3.zero;

    }

    private void Run()
    {

        if(Mathf.Abs(_forInput) > INPUT_DELAY)
        {
            _rigid.velocity = transform.forward * _forInput * FORWARD_SPEED;
            return;
        }
        _rigid.velocity = Vector3.zero;
    }

    private void Jump()
    {
        _rigid.velocity = transform.forward * JUMP_FACTOR;
    }

    private AnimationState GetInput()
    {
        if (_player.Dead)
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
}
