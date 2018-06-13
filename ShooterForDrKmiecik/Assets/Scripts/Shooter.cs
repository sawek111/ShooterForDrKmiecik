using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Shooter
{
    [Inject] private Settings _settings = null;

    private Transform _sourceTransform = null;
    private MonoBehaviour _coroutineKeeper = null;
    private Animator _animator = null;
    private ShooterType _type;

    [Inject]
    public Shooter(Transform sourceTransform, MonoBehaviour coroutineKeeper, Animator animator, ShooterType type)
    {
        _sourceTransform = sourceTransform;
        _coroutineKeeper = coroutineKeeper;
        _animator = animator;
        _type = type;
    }


    public void Shoot()
    {
        _coroutineKeeper.StartCoroutine(WaitForShoot());
    }

    public void Shoot(Transform target)
    {
        _coroutineKeeper.StartCoroutine(WaitForShoot(target));
    }

    private IEnumerator WaitForShoot()
    {
        float t = 0f;
        while(t < 3f)
        {
            t += Time.deltaTime;
            AnimatorTransitionInfo transitionInfo = _animator.GetAnimatorTransitionInfo(0);
            if (transitionInfo.normalizedTime >= GetTypeNormalizedTime())
            {
                GameObject.Instantiate(_settings.LaserPrefab, _sourceTransform.position + _sourceTransform.transform.forward, _sourceTransform.rotation, null);
                break;
            }

            yield return null;
        }
    }


    private IEnumerator WaitForShoot(Transform target)
    {
        float t = 0f;
        while (t < 3f)
        {
            t += Time.deltaTime;
            AnimatorTransitionInfo transitionInfo = _animator.GetAnimatorTransitionInfo(0);
            if (transitionInfo.normalizedTime >= GetTypeNormalizedTime())
            {
                _sourceTransform.LookAt(target);
                Vector3 source = _sourceTransform.position + _sourceTransform.transform.forward;
             
                GameObject.Instantiate(_settings.LaserPrefab, source , _sourceTransform.rotation, null);
                break;
            }

            yield return null;
        }
    }

    private float GetTypeNormalizedTime()
    {
        switch (_type)
        {
            case ShooterType.Enemy:
            {
                return _settings.EnemyShootTimeNormalized;
            }
            case ShooterType.Player:
            {
                return _settings.PlayerShootTimeNormalized;
            }
        }

        return 0f;
    }

    [Serializable]
    public class Settings
    {
        [Range(0f,1f)] public float EnemyShootTimeNormalized;
        [Range(0f, 1f)] public float PlayerShootTimeNormalized;

        public GameObject LaserPrefab;

    }
}
