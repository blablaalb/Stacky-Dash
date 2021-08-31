using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class Multiplier : MonoBehaviour
{
    private MeshRenderer[] _meshRenderers;

    internal void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>().Where(x => x.CompareTag(BoundsCube.Tag)).ToArray();
    }

    internal void Start()
    {
        AssignRandomMaterialColor();
    }

    private void AssignRandomMaterialColor()
    {

        Material mat = new Material(_meshRenderers[0].material)
        {
            color = Random.ColorHSV()
        };

        foreach (var mr in _meshRenderers)
        {
            mr.sharedMaterial = mat;
        }
    }
}
