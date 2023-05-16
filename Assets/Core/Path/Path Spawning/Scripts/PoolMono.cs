using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    [SerializeField] private T[] _prefabs;
    [SerializeField] private Transform _defaultPosition;

    private List<T> _pool;
    private bool _activeByDefault;

    public PoolMono(T[] prefabs, Transform defaultPosition, int count, bool activeByDefault)
    {
        _prefabs = prefabs;
        _activeByDefault = activeByDefault;
        _defaultPosition = defaultPosition;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
            CreateElement();
    }

    private void CreateElement()
    {
        for (int i = 0; i < _prefabs.Length; i++)
        {
            var created = Object.Instantiate(_prefabs[Random.Range(0, _prefabs.Length)], _defaultPosition);
            created.gameObject.SetActive(_activeByDefault);
            _pool.Add(created);

            if (i == _prefabs.Length - 1) i = -1;
        }
    }

    public T GetFreeElement(Vector3 position)
    {
        if (!HasFreeElements(out List<T> elements))
            throw new System.Exception($"no free elements in pool of {typeof(T)}");

        return SetupElement(elements[0], position);
    }

    public T GetFreeRandomElement(Vector3 position)
    {
        if (!HasFreeElements(out List<T> elements))
            throw new System.Exception($"no free elements in pool of {typeof(T)}");

        return SetupElement(elements[Random.Range(0, elements.Count)], position);
    }

    private T SetupElement(T element, Vector3 position)
    {
        element.gameObject.SetActive(true);
        element.transform.position = position;
        return element;
    }

    public bool HasFreeElements() => HasFreeElements(out var elements);

    public bool HasFreeElements(out List<T> elements)
    {
        elements = new List<T>();
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
                elements.Add(item);
        }

        if (elements.Count > 0)
            return true;
        return false;
    }
}