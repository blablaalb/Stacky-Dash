using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(Cube), true)]
public class CubeEditor : Editor
{
    private int _paveCount;
    private Cube _targetCube;
    private static GameObject[] _selectedGameObjects;

    public override void OnInspectorGUI()
    {
        _targetCube = target as Cube;

        DrawDefaultInspector();
        _paveCount = EditorGUILayout.IntField("Pave Count", _paveCount);

        if (GUILayout.Button("Pave"))
        {
            PaveCubes();
        }
    }

    private Cube[] PaveCubes()
    {
        int count = _paveCount;
        Cube[] cubes = new Cube[count];
        Cube cube = _targetCube;
        for (int i = 0; i < count; i++)
        {
            cube = Pave(cube);
            cubes[i] = cube;
        }

        return cubes;
    }

    private static Cube Pave(Cube after)
    {
        var c = PrefabUtility.GetCorrespondingObjectFromSource(after.gameObject);
        var go = PrefabUtility.InstantiatePrefab(c, after.transform.parent) as GameObject;
        Cube newCube = go.GetComponent<Cube>();
        var position = after.transform.position;
        var rotation = after.transform.rotation;
        position += after.transform.forward * 1;
        newCube.transform.position = position;
        newCube.transform.rotation = rotation;
        _selectedGameObjects = Selection.gameObjects;
        Selection.activeObject = newCube.gameObject;
        AddSelection(newCube.gameObject);
        if (newCube is BoundsCube bc)
        {
            bc.Visible = ((BoundsCube)after).Visible;
        }
        return newCube;
    }

    private static void AddSelection(GameObject go)
    {
        if (!_selectedGameObjects.Contains(go))
            _selectedGameObjects = _selectedGameObjects.Append(go).ToArray();
        Selection.objects = _selectedGameObjects;
    }

}