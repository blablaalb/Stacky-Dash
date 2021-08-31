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
    [SerializeField]
    private GameObject _finishPrefab;
    private bool _finished;
    private CubeStack _cubeStack;

    internal void Awake()
    {
        _cubeStack = FindObjectOfType<CubeStack>();
    }

    internal void OnTriggerEnter(Collider other)
    {
        if (_finished) return;

        MultiplierTrack lastMultiplierTrack = null;
        if (other.gameObject.CompareTag(Player.Tag))
        {
            _finished = true;
            var cnt = CalculateLength();
            var tracks = InstantiateMultiplierTracks(cnt);
            lastMultiplierTrack = tracks.Last();
        }

        var finishPosition = lastMultiplierTrack.transform.position + lastMultiplierTrack.transform.forward * MultiplierTrack.Length;
        InstantiateFinishPrefab(finishPosition);
    }

    private int CalculateLength()
    {
        int length = _cubeStack.Count / 5;
        return length;
    }

    private MultiplierTrack[] InstantiateMultiplierTracks(int count)
    {
        var position = _end.position;
        MultiplierTrack[] tracks = new MultiplierTrack[count];
        for (int i = 0; i < count; i++)
        {
            var track = InstantiateMultiplierTrack(position);
            tracks[i] = track;
            position = track.transform.position + track.transform.forward * MultiplierTrack.Length;
            track.SetMultiplier(i);
        }

        return tracks;
    }

    private MultiplierTrack InstantiateMultiplierTrack(Vector3 position)
    {
        var multiplier = Instantiate<GameObject>(_multiplierPrefab).GetComponent<MultiplierTrack>();
        multiplier.transform.position = position;
        return multiplier;
    }

    private GameObject InstantiateFinishPrefab(Vector3 position)
    {
        var finish = Instantiate<GameObject>(_finishPrefab);
        finish.transform.position = position;
        return finish;
    }
}