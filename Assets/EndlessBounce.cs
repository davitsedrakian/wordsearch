using UnityEngine;
using TMPro;
using DG.Tweening;

public class EndlessBounce : MonoBehaviour
{
    [SerializeField] private float maxScale;
    [SerializeField] private float bounceTime;

    void Start()
    {
        StartBouncing();
    }

    void StartBouncing()
    {
        Sequence bounceSequence = DOTween.Sequence()
            .Append(transform.DOScale(maxScale, bounceTime/2))
            .Append(transform.DOScale(1f, bounceTime/2))
            .SetLoops(-1);
    }
    
    private void OnDestroy()
    {
        DOTween.KillAll();
    }
}