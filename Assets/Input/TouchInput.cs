using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour, IInput
{
    private Vector2 _delta;
    
    public Vector2 Delta { get { return _delta; } }

    internal void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.touches[0];
        var delta = touch.deltaPosition;
        if (Mathf.Abs(delta.x) < Mathf.Abs(delta.y))
        {
            _delta = new Vector2(0, delta.y);
        }
        else if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            _delta = new Vector2(delta.x, 0);
        }
    }
}
