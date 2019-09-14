using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Hashtag : MonoSingleton<Hashtag>
{
    protected override bool DestroyOnLoad => true;
    public Text[] texts;
    
    public float duration = 4;

    public void SetTexts(List<string> tags, List<Color> colours)
    {
        var i = 0;
        for (; i != tags.Count && i != texts.Length; ++i)
        {
            texts[i].text = $"#{tags[i]}";
            texts[i].transform.parent.gameObject.SetActive(true);
            texts[i].transform.parent.GetComponent<Image>().color = colours[i];
        }

        for (; i < texts.Length; ++i)
        {
            texts[i].transform.parent.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        foreach (var text in texts)
        {
            text.transform.parent.DOShakeRotation(duration, new Vector3(0,0, 5), 10, 90f, false).SetLoops(-1, LoopType.Restart);
        }
    }
}
