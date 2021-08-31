using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class BoundsCube : Cube
{
    [SerializeField]
    private bool _visible = true;
    private MeshRenderer _meshRenderer;

    public static string Tag => "Bounds";

    override protected void Awake()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _meshRenderer.enabled = _visible;
        gameObject.tag = Tag;
    }
}