using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;
using Object = UnityEngine.Object;
using System.Collections.ObjectModel;

public class CubeStack : MonoBehaviour
{
    private List<CollectableCube> _collection = new List<CollectableCube>();

    public ReadOnlyCollection<CollectableCube> Stack => new ReadOnlyCollection<CollectableCube>(_collection);
    public event Action<CollectableCube> Added;
    public event Action<CollectableCube> Removed;

    public bool Contains(CollectableCube cube) => _collection.Contains(cube);

    public CollectableCube GetTop()
    {
        if (_collection.Count<=0) return null;

        var top = _collection.OrderBy(x => x.transform.position.y).Last();
        return top;
    }

    /// <summary>
    /// Adds cube to collection if the cube is not already in the collection.
    /// </summary>
    /// <param name="cube"></param>
    /// <returns>True if added to the collection. False otherwise.</returns>
    public bool Add(CollectableCube cube)
    {
        if (!Contains(cube))
        {
            cube.PlayCollectAudio();
            _collection.Add(cube);
            cube.transform.SetParent(this.transform);
            MoveToTop(cube);
            Added?.Invoke(cube);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns cube if collection is not empty. Returns null otherwise.
    /// </summary>
    /// <returns>Cube or null</returns>
    public CollectableCube Get()
    {
        if (_collection.Count <= 0) return null;
        int indx = _collection.Count - 1;
        var cube = _collection[indx];
        _collection.RemoveAt(indx);
        Removed?.Invoke(cube);
        return cube;
    }

    private void MoveToTop(CollectableCube cube)
    {
        if (!Contains(cube)) throw new Exception("Cube msut be in collection");
        int count = _collection.Count;
        float cubeHeight = cube.Dimension.y;
        var stackHeight = count * cubeHeight;
        var position = new Vector3(0f, stackHeight - cubeHeight, 0f);
        cube.transform.localPosition = position;
    }
}