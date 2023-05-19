using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPool<T> where T : Entity
{
    private List<T> _pool;
    private int _size;

    public EntityPool(T[] prefabs, int size)
    {
        _size = size;
        CreatePool(prefabs);
    }

    public bool HasElement()
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
                return true;
        }
        return false;
    }

    public List<T> GetFreeElements() => GetElements(false);

    public List<T> GetActiveElements() => GetElements(true);

    public List<T> GetElements(bool active)
    {
        var elements = new List<T>();
        foreach (var item in _pool)
        {
            if ((item.gameObject.activeInHierarchy && active) ||
                (!item.gameObject.activeInHierarchy && !active))
                elements.Add(item);
        }
        return elements;
    }

    public T GetRandomElement(Vector3 position)
    {
        if (!HasElement())
            throw new System.InvalidOperationException();

        var elements = GetFreeElements();

        var element = elements[Random.Range(0, elements.Count)];
        element.transform.position = position;
        element.gameObject.SetActive(true);
        
        return element;
    }

    private void CreatePool(T[] prefabs)
    {
        _pool = new List<T>(_size);
        var j = 0;

        for (int i = 0; i < _size; i++)
        {
            var element = Object.Instantiate(prefabs[j]);
            element.gameObject.SetActive(false);
            _pool.Add(element);

            if (++j == prefabs.Length) j = 0;
        }
    }
}
