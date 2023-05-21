using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILoader : MonoBehaviour
{
    [SerializeField] private View _pauseView;
    [SerializeField] private View _loseView;
    [SerializeField] private View _finishView;

    [SerializeField] private TextMeshProUGUI _globalCoinsText;
    [SerializeField] private TextMeshProUGUI _finishCoinsText;

    public void LoadCoinsText(int value) => _globalCoinsText.text = GetShortedNumericString(value);

    public void ShowPauseView() => ShowView(_pauseView);

    public void ShowLoseView() => ShowView(_loseView);

    public void ShowFinishView(int coinsCount)
    {
        _finishCoinsText.text = "+" + GetShortedNumericString(coinsCount);
        ShowView(_finishView);
    }

    public void ShowView(View view)
    {
        view.Show();
    }

    private string GetShortedNumericString(int value)
    {
        var numericLevelSymbols = new Dictionary<int, string>()
        {
            { 0, "" },
            { 1, "K" },
            { 2, "M" },
            { 3, "B" },
        };

        int level = 1;
        for (level = 1; ; level++)
        {
            if (value / Mathf.Pow(1000, level) < 1)
            {
                --level;
                break;
            }
        }
        Debug.Log(level);

        return Math.Round((float)value / Mathf.Pow(1000, level), 2).ToString() + numericLevelSymbols[level];
    }
}
