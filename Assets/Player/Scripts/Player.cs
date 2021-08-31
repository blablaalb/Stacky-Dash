using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _gravity = 9.8f;
    [SerializeField]
    private Transform _model;
    private CubeStack _cubeStack;

    public static string Tag => "Player";

    internal void Awake()
    {
        _cubeStack = GetComponent<CubeStack>();
        Physics.gravity = Vector3.zero;
    }

    internal void Start()
    {
        _cubeStack.Added += OnCubeAdded;
        _cubeStack.Removed += OnCubeRemoved;
    }

    internal void OnDestroy()
    {
        _cubeStack.Added -= OnCubeAdded;
        _cubeStack.Removed -= OnCubeRemoved;
    }

    private void OnCubeAdded(Cube cube)
    {
        AdjustModelPosition();
    }

    private void OnCubeRemoved(Cube cube)
    {
        AdjustModelPosition();
    }

    private void AdjustModelPosition()
    {
        var top = _cubeStack.GetTop();
        if (top != null)
            _model.position = top.transform.position;
    }


    public void Left()
    {
        Physics.gravity = Vector3.left * _gravity;
    }

    public void Right()
    {
        Physics.gravity = Vector3.right * _gravity;
    }

    public void Forward()
    {
        Physics.gravity = Vector3.forward * _gravity;
    }

    public void Back()
    {
        Physics.gravity = -Vector3.forward * _gravity;
    }
}