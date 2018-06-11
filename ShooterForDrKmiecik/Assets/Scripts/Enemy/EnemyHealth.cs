using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyHealth: IInitializable
{
    [Inject] private Settings _settings = null;

    public int CurrentHealth { get; set; }

    public void Initialize()
    {
        CurrentHealth = _settings.StartHealth;
    }

    public void ChangeHealth(int change)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + change, 0, _settings.MaxHealth);
    }

    public int GetMaxHealth()
    {
        return _settings.MaxHealth;
    }


    [Serializable]
    public class Settings
    {
        public int StartHealth;
        public int MaxHealth;
    }

}
