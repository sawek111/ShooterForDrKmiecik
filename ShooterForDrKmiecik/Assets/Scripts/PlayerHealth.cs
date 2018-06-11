using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealth : IInitializable
{
    [Inject] private Settings _settings = null;

    private int _currHealth = 100;

    public void Initialize()
    {
        _currHealth = _settings.StartHP;
    }

    public bool Dead
    {
        get { return _currHealth <= 0; }
    }

    public void ChangeHealth(int change)
    {
        _currHealth = Mathf.Clamp(_currHealth + change, 0, _settings.MaxHP);
    }

    [Serializable]
    public class Settings
    {
        public int MaxHP;
        public int StartHP;
    }
}
