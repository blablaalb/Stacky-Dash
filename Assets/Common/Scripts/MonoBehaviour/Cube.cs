using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

[RequireComponent(typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    protected BoxCollider _boxCollider;
    [SerializeField]
    protected bool _isTrigger;

    public Vector3 Dimension => transform.localScale;

    virtual protected void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _boxCollider.isTrigger = _isTrigger;
    }


}