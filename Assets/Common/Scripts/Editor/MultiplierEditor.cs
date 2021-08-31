using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using UnityEditor;

[CustomEditor(typeof(MultiplierTrack))]
public class MultiplierEditor : Editor
{
    private int _paveCount;
    private MultiplierTrack _targetMultiplier;
    private static GameObject[] _selectedGameObjects;

    public override void OnInspectorGUI()
    {
        _targetMultiplier = target as MultiplierTrack;

        DrawDefaultInspector();
        _paveCount = EditorGUILayout.IntField("Pave Count", _paveCount);

        if (GUILayout.Button("Pave"))
        {
            PaveMultipliers();
        }
    }

    private MultiplierTrack[] PaveMultipliers()
    {
        int count = _paveCount;
        MultiplierTrack[] Multipliers = new MultiplierTrack[count];
        MultiplierTrack Multiplier = _targetMultiplier;
        for (int i = 0; i < count; i++)
        {
            Multiplier = Pave(Multiplier);
            Multipliers[i] = Multiplier;
        }

        return Multipliers;
    }

    private static MultiplierTrack Pave(MultiplierTrack after)
    {
        var c = PrefabUtility.GetCorrespondingObjectFromSource(after.gameObject);
        var go = PrefabUtility.InstantiatePrefab(c, after.transform.parent) as GameObject;
        MultiplierTrack newMultiplier = go.GetComponent<MultiplierTrack>();
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