using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using System;

public class LootCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _animationDuration = 2f;
    [SerializeField] private float _animationPulseIntensivity = 0.2f;

    public int Count { get; private set; }

    private void Start()
    {
        _text.text = Count.ToString();
    }

    public void Add()
    {
        Count++;
        AnimateTextPulsed(0.05f, Count.ToString());
        _text.text = Count.ToString();
    }

    public void Reset()
    {
        Count = 0;
        _text.text = Count.ToString();
    }

    public void AnimateToZero()
    {
        StartCoroutine(AnimateDiscarding());
        Reset();
    }

    private IEnumerator AnimateDiscarding()
    {
        var duration = _animationDuration / Count;

        for (int i = Count; i  >= 0; i--)
        {
            AnimateTextPulsed(duration, i.ToString());
            yield return new WaitForSeconds(duration * 2);
        }
    }

    private void AnimateTextPulsed(float duration, string content)
    {
        var currentScale = transform.localScale;

        transform.DOScale(currentScale * (1 - _animationPulseIntensivity), duration)
                .SetLoops(2, LoopType.Yoyo)
                .SetLink(gameObject)
                .OnKill(() => _text.text = content);
    }
}
