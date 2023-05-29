using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UILoader : MonoBehaviour
{
    [SerializeField] private View _pauseView;
    [SerializeField] private View _loseView;
    [SerializeField] private View _finishView;

    [SerializeField] private TextMeshProUGUI _finishCoinsText;
    [SerializeField] private float _animationPulseIntensivity = 0.1f;
    [SerializeField] private float _animationDuration = 2f;


    public void ShowPauseView() => ShowView(_pauseView);

    public void ShowLoseView() => ShowView(_loseView);

    public void ShowFinishView(int coinsCount)
    {
        ShowView(_finishView);
        StartCoroutine(AnimateFinishView(coinsCount));
    }

    private IEnumerator AnimateFinishView(int count)
    {
        var duration = _animationDuration / count;
        for (int i = 0; i <= count; i++)
        {
            var currentScale = transform.localScale;

            transform.DOScale(currentScale * (1 - _animationPulseIntensivity), duration)
                .SetLoops(2, LoopType.Yoyo)
                .SetLink(_finishCoinsText.gameObject)
                .OnKill(() => _finishCoinsText.text = "+" + i.ToString());

            yield return new WaitForSeconds(duration * 2);
        }
    }

    public void ShowView(View view)
    {
        view.Show();
    }
}
