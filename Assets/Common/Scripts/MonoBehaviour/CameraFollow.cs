using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField]
    private Transform _target;

    internal void Awake()
    {
        _offset = transform.position - _target.position;
    }
}