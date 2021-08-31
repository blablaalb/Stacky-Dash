using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using Common;

public class LevelManager : Singleton<LevelManager>
{
    private bool _finished;

    public event Action<FinishResult> LevelFinished;

    internal void Start()
    {
        CollectableCube.Collected += OnCubeCollected;
        CollectableCube.Dropped += OnCubeLost;
    }

    override protected void OnDestroy()
    {
        CollectableCube.Collected -= OnCubeCollected;
        CollectableCube.Dropped -= OnCubeLost;
    }

    private void OnCubeCollected(CollectableCube cube)
    {
        if (!FinishLine.Instance.Reached)
            GemsManager.AddGems(1);
    }

    private void OnCubeLost(CollectableCube cube)
    {
        if (!FinishLine.Instance.Reached)
            GemsManager.RemoveGems(1);
    }


    public void OnFinishReached()
    {
        if (_finished) return;
        LevelFinished?.Invoke(FinishResult.Won);
        _finished = true;
    }
}

public enum FinishResult
{
    Won,
    Lost
}