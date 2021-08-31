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

    public void OnFinishedReached()
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