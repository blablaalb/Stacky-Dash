using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using Common;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    public void LoadNextScene()
    {
        var activeScene = SceneManager.GetActiveScene();
        var indx = activeScene.buildIndex + 1;
        if (indx < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indx);
        }
    }
}