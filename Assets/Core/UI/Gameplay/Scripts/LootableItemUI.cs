using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableItemUI : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _duration = 1f;

    public void Move(Vector2 from, Vector2 to, bool stayActive)
    {
        StartCoroutine(StartMovement(from, to, stayActive));
    }

    private IEnumerator StartMovement(Vector2 from, Vector2 to, bool stayActive)
    {
        for (float t = 0; t < _duration; t += Time.deltaTime)
        {
            transform.position = Vector2.Lerp(from, to, _curve.Evaluate(t / _duration));
            yield return null;
        }
        gameObject.SetActive(stayActive);
    }
}
