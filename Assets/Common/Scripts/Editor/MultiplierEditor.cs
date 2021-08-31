using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using UnityEditor;

[CustomEditor(typeof(Multiplier))]
public class MultiplierEditor : Editor
{
    private int _paveCount;
    private Multiplier _targetMultiplier;
    private static GameObject[] _selectedGameObjects;

    public override void OnInspectorGUI()
    {
        _targetMultiplier = target as Multiplier;

        DrawDefaultInspector();
        _paveCount = EditorGUILayout.IntField("Pave Count", _paveCount);

        if (GUILayout.Button("Pave"))
        {
            PaveMultipliers();
        }
    }

    private Multiplier[] PaveMultipliers()
    {
        int count = _paveCount;
        Multiplier[] Multipliers = new Multiplier[count];
        Multiplier Multiplier = _targetMultiplier;
        for (int i = 0; i < count; i++)
        {
            Multiplier = Pave(Multiplier);
            Multipliers[i] = Multiplier;
        }

        return Multipliers;
    }

    private static Multiplier Pave(Multiplier after)
    {
        var c = PrefabUtility.GetCorrespondingObjectFromSource(after.gameObject);
        var go = PrefabUtility.InstantiatePrefab(c, after.transform.parent) as GameObject;
        Multiplier newMultiplier = go.GetComponent<Multiplier>();
        var position = after.transform.position;
        var rotation = after.transform.rotation;
        position += after.transform.forward * 7;
        newMultiplier.transform.position = position;
        newMultiplier.transform.rotation = rotation;
        _selectedGameObjects = Selection.gameObjects;
        Selection.activeObject = newMultiplier.gameObject;
        AddSelection(newMultiplier.gameObject);
        return newMultiplier;
    }

    private static void AddSelection(GameObject go)
    {
        if (!_selectedGameObjects.Contains(go))
            _selectedGameObjects = _selectedGameObjects.Append(go).ToArray();
        Selection.objects = _selectedGameObjects;
    }
}