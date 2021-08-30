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

    // FIXME: add InputManager for TouchInput and KeyboardInput
    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Physics.gravity = Vector3.forward * _gravity;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Physics.gravity = Vector3.right * _gravity;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Physics.gravity = Vector3.left * _gravity;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Physics.gravity = -Vector3.forward * _gravity;
        }
    }
}