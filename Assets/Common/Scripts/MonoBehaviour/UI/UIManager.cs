using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _successImg;
    [SerializeField]
    private GameObject _failureImg;
    [SerializeField]
    private GameObject _continueBtn;

    internal void Start()
    {
        LevelManager.Instance.LevelFinished += OnLevelFinished;
        _continueBtn.SetActive(false);
        _successImg.SetActive(false);
        _failureImg.SetActive(false);
    }

    internal void OnDestroy()
    {
        if (LevelManager.Instance)
            LevelManager.Instance.LevelFinished -= OnLevelFinished;
    }

    private void OnLevelFinished(FinishResult result)
    {
        if (result == FinishResult.Won)
        {
            _successImg.SetActive(true);
        }

        _continueBtn.SetActive(true);
    }
}