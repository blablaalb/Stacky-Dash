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
    [SerializeField]
    private TMPro.TextMeshProUGUI _gemsText;

    internal void Start()
    {
        LevelManager.Instance.LevelFinished += OnLevelFinished;
        GemsManager.GemsAdded += OnGemsAdded;
        GemsManager.GemsRemoved += OnGemsRemoved;
        _continueBtn.SetActive(false);
        _successImg.SetActive(false);
        _failureImg.SetActive(false);
        UpdateGems();
    }

    internal void OnDestroy()
    {
        if (LevelManager.Instance)
            LevelManager.Instance.LevelFinished -= OnLevelFinished;

        GemsManager.GemsAdded -= OnGemsAdded;
        GemsManager.GemsRemoved -= OnGemsRemoved;
    }

    private void OnGemsAdded(int added)
    {
        UpdateGems();
    }

    private void OnGemsRemoved(int added)
    {
        UpdateGems();
    }

    private void UpdateGems()
    {
        int gems = GemsManager.Gems;
        _gemsText.SetText(gems.ToString());
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