using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class InputManager : MonoBehaviour
{
    private Player _player;
    private IInput _input;

    internal void Awake()
    {
        _player = GetComponent<Player>();
#if UNITY_EDITOR
        _input = gameObject.AddComponent<KeyboardInput>();
#elif UNITY_ANDROID
        _input = FindObjectOfType<TouchInput>();
#endif
    }

    internal void Update()
    {
        var delta = _input.Delta;
        if (delta.y < 0) _player.Back();
        else
        if (delta.y > 0) _player.Forward();
        else
        if (delta.x > 0) _player.Right();
        else
        if (delta.x < 0) _player.Left();
    }
}