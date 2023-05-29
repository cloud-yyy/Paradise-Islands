using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _count;
    public int Count
    {
        get { return _count; }
        set
        {
            if (value < 0 ) throw new ArgumentException(nameof(_count));
            
            _count = value;
            AnimateCount();
            _text.text = value.ToString();
        }
    }

    private void AnimateCount()
    {
        transform?
            .DOScale(transform.localScale * 1.1f, 0.05f)
            .SetLoops(2, LoopType.Yoyo)
            .SetUpdate(UpdateType.Normal, true)
            .SetLink(gameObject);
    }
}
