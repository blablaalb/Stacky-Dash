using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class Path : Cube
{
    private CubeStack _cubeStack;
    private CollectableCube _requestedCube;

    override protected void Awake()
    {
        base.Awake();
        _cubeStack = FindObjectOfType<CubeStack>();
    }

    internal void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player.Tag))
        {
            RequestCube();
        }
    }

    private bool RequestCube()
    {
        if (_requestedCube != null) return true;
        var cube = _cubeStack.Get();
        if (cube)
        {
            cube.Drop();
            _requestedCube = cube;
            _requestedCube.transform.SetParent(transform);
            _requestedCube.transform.localPosition = Vector3.zero;
        }
        return cube;
    }
}