using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHealth : IInitializable
{
    [Inject] private Settings _settings = null;

    public int Health { get; set; }

    public void Initialize()
    {
        Health = _settings.StartHP;
    }

    public bool Dead
    {
        get { return Health <= 0; }
    }

    public void ChangeHealth(int change)
    {
        Health = Mathf.Clamp(Health + change, 0, _settings.MaxHP);
    }


    [Serializable]
    public class Settings
    {
        public int MaxHP;
        public int StartHP;
    }
}
