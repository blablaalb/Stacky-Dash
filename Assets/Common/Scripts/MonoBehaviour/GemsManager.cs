using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Gems Manager", menuName = "Create/Gems Manager")]
public class GemsManager : ScriptableObject
{
    public static int Gems { get; private set; }
    public static event Action<int> GemsAdded;
    public static event Action<int> GemsRemoved;

    public static void AddGems(int count)
    {
        Gems += count;
        GemsAdded?.Invoke(count);
    }

    public static void RemoveGems(int count)
    {
        Gems -= count;
        GemsRemoved?.Invoke(count);
    }
}