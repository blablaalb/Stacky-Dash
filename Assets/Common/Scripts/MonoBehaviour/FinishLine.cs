using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private Transform _end;
    [SerializeField]
    private GameObject _multiplierPrefab;
    private bool _finished;
    private CubeStack _cubeStack;

    internal void Awake()
    {
        _cubeStack = FindObjectOfType<CubeStack>();
    }

    internal void OnTriggerEnter(Collider other)
    {
        if (_finished) return;
        if (other.gameObject.CompareTag(Player.Tag))
        {
            var cnt = CalculateLength();
            InstantiateMultiplierTracks(cnt);
            _finished = true;
        }
    }

    private int CalculateLength()
    {
        int length = _cubeStack.Count / 5;
        return length;
    }

    private Multiplier[] InstantiateMultiplierTracks(int count)
    {
        var position = _end.position;
        Multiplier[] tracks = new Multiplier[count];
        for (int i = 0; i < count; i++)
        {
            var multiplier = InstantiateMultiplierTrack(position);
            int multiplierLength = 7;
            position = multiplier.transform.position + multiplier.transform.forward * multiplierLength;
        }

        return tracks;
    }

    private Multiplier InstantiateMultiplierTrack(Vector3 position)
    {
        var multiplier = Instantiate<GameObject>(_multiplierPrefab).GetComponent<Multiplier>();
        multiplier.transform.position = position;
        return multiplier;
    }
}