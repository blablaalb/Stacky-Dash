using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using TMPro;

public class MultiplierTrack : MonoBehaviour
{
    private MeshRenderer[] _meshRenderers;
    private TextMeshPro _tmPro;

    public float Multiplier { get; private set; }
    public static int Length => 7;

    internal void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>().Where(x => x.CompareTag(BoundsCube.Tag)).ToArray();
        _tmPro = GetComponentInChildren<TextMeshPro>();
    }

    internal void Start()
    {
        AssignRandomMaterialColor();
    }

    public void SetMultiplier(float multiplier)
    {
        Multiplier = multiplier;
        _tmPro.SetText($"x{multiplier:0.00}");
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
