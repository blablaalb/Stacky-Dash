using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class KeyboardInput : MonoBehaviour, IInput
{
    private Vector2 _delta;
    
    public Vector2 Delta { get { return _delta; } }

    internal void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) _delta = Vector2.left;
        else 
        if (Input.GetKeyDown(KeyCode.D)) _delta = Vector2.right;
        else 
        if (Input.GetKeyDown(KeyCode.W)) _delta = Vector2.up;
        else 
        if (Input.GetKeyDown(KeyCode.S)) _delta = Vector2.down;
    }
}