using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _itemsUIPoolSize;

    public int Count { get; private set; }

    private void Start()
    {
        _text.text = Count.ToString();
    }

    public void Add()
    {
        Count++;
        _text.text = Count.ToString();
    }

    public void Reset()
    {
        Count = 0;
        _text.text = Count.ToString();
    }
}
