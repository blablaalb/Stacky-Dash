using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class Finish : MonoBehaviour
{
    private ParticleSystem _particleSys;

    internal void Awake()
    {
        _particleSys = GetComponentInChildren<ParticleSystem>();
    }

    internal void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Player.Tag))
        {
            LevelManager.Instance.OnFinishReached();
            _particleSys.Play();
        }
    }
}