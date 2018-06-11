using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HealArea : MonoBehaviour
{
    [Inject] private Settings _settings = null;

    public void OnTriggerStay(Collider other)
    {
        IHealable healable = other.GetComponent<IHealable>();
        if(healable != null)
        {
            healable.Heal(_settings.HealingValue);
        }
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

    [Serializable]
    public class Settings
    {
        public int HealingValue;
    }
}
