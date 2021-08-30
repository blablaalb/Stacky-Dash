using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class CollectableCube : Cube
{
    private CubeStack _cubeStack;
    [SerializeField]
    private AudioClip[] _collectedAudClips;
    [SerializeField]
    private AudioClip _dropAudClip;
    [SerializeField]
    private Material _dropMaterial;
    private bool _collected;
    private MeshRenderer _meshRenderer;

    override protected void Awake()
    {
        base.Awake();
        _cubeStack = FindObjectOfType<CubeStack>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    internal void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Player.Tag))
        {
            Collect();
        }
    }

    private void Collect()
    {
        if (!_collected)
            _collected = _cubeStack.Add(this);
    }

    public void Drop()
    {
        PlayDropAudio();
        ChangeMaterialToDrop();
    }

    private void ChangeMaterialToDrop()
    {
        _meshRenderer.sharedMaterial = _dropMaterial;
    }

    public void PlayDropAudio()
    {
        AudioPlayer.Instance.PlayAudioCLip(_dropAudClip);
    }


    public void PlayCollectAudio()
    {
        AudioPlayer.Instance.PlayRandomAudioClip(_collectedAudClips);
    }
}