using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Settings _settings = null;

    public void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * _settings.Speed;
        GameObject.Destroy(gameObject, 2f);
    }

    public void OnTriggerEnter(Collider other)
    {
        IHurtable hurtableObject = other.GetComponent<IHurtable>();
        if(hurtableObject != null)
        {
            hurtableObject.Hurt(_settings.HurtValue);
        }

        Destroy(gameObject);
    }

    [Serializable]
    public class Settings
    {
        public float Speed;
        public int HurtValue;
    }
}
