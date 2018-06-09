using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] Settings _settings = null;

    private int _currHealth = 100;

    public void Awake()
    {
        _currHealth = _settings.MaxHP;        
    }

    public  bool Dead
    {
        get { return _currHealth <= 0; }
    }

    public void ApplyDamage(int damage)
    {
        _currHealth = (int)Mathf.Clamp(_currHealth - damage, 0f, _settings.MaxHP);
    }

    public void Heal(int value)
    {
        _currHealth = (int)Mathf.Clamp(_currHealth + value, 0f, _settings.MaxHP);
    }

    [Serializable]
    public class Settings
    {
        public int MaxHP;
        public int StartHP;
    }
}
