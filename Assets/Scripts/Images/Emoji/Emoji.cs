using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SVGImage))]
public class Emoji : MonoBehaviour
{
    public SVGImage svg
    {
        get
        {
            if (_svg == null)
            {
                _svg = GetComponent<SVGImage>();
            }

            return _svg;
        }
    }

    private SVGImage _svg;
    
    public float duration = 1;
    public Ease ease = Ease.InCirc;
    public float maxSize = 2;
    private void Start()
    {
        transform.DOScale(Vector3.one * maxSize, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
    }
}
