using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class View : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private float _showHideDuration = 0.15f;
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _closeButton.onClick.AddListener(Hide);

        _canvasGroup = GetComponent<CanvasGroup>();
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        AnimateScale();
        AnimateFade(1f);
    }

    public void Hide()
    {
        AnimateScale();
        AnimateFade(0f, () => gameObject.SetActive(false));
    }

    private void AnimateFade(float targetValue, Action onComplete = null)
    {
        _canvasGroup?
            .DOFade(targetValue, _showHideDuration)
            .SetUpdate(UpdateType.Normal, true)
            .SetLink(gameObject)
            .OnComplete(() => onComplete?.Invoke());
    }

    private void AnimateScale()
    {
        transform?
            .DOScale(transform.localScale * 1.1f, _showHideDuration / 2)
            .SetLoops(2, LoopType.Yoyo)
            .SetUpdate(UpdateType.Normal, true)
            .SetLink(gameObject);
    }
}
