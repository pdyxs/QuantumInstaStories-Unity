using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashtagEffect : QuantumEffect
{
    protected override void UpdateStyle(EmotionStyler[] oldStyles)
    {
        var hashtags = new List<string>();
        var colours = new List<Color>();
        foreach (var style in currentStyles)
        {
            hashtags.Add(style.hashtags[Random.Range(0, style.hashtags.Length)]);
            colours.Add(style.hashtagColour);
        }
        Hashtag.instance.SetTexts(hashtags, colours);
    }
}
