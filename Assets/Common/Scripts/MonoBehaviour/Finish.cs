using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

public class Finish : MonoBehaviour
{
    internal void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Player.Tag))
        {
            LevelManager.Instance.OnFinishedReached();
        }
    }
}