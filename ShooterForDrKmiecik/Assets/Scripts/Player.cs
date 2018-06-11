using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

{
    private PlayerHealth _health = null;
    private PlayerCharacterController _characterController = null;

    [Inject]
    public void Construct(PlayerHealth playerHealth, PlayerCharacterController characterController)
    {
        _health = playerHealth;
        _characterController = characterController;
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

    public Transform Transform
    {
        get { return transform; }
    }

    public bool IsRotation
    {
        get { return _characterController.IsRotation; }
    }

    public Quaternion TargetRotation
    {
        get { return _characterController.TargetRotation; }
    }

    public void Heal(int value)
    {
        _health.ChangeHealth(value);
    }

    public void Hurt(int value)
    {
        _health.ChangeHealth(-value);
    }


}
