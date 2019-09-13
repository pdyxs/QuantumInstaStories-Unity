using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuantumStylers : MonoSingleton<QuantumStylers>
{
    protected override bool DestroyOnLoad => true;

    public List<EmotionStyler> stylers;

    public EmotionStyler[] GetMatchingStylers(QuantumEmotions.Emotion[] emotions, Type effectType)
    {
        List<EmotionStyler> bestMatches = new List<EmotionStyler>();
        int numberOfMatches = 0;
        foreach (var styler in stylers)
        {
            if (!styler.SupportsEffect(effectType)) 
                continue;

            if (styler.emotions.Length > emotions.Length)
                continue;
            
            var match = 0;
            bool end = false;
            foreach (var emotion in styler.emotions)
            {
                if (emotions.Contains(emotion))
                {
                    match++;
                }
                else
                {
                    end = true;
                    break;
                }
            }
            if (end) continue;

            if (match > numberOfMatches)
            {
                numberOfMatches = match;
                bestMatches.Clear();
                bestMatches.Add(styler);
            } else if (match == numberOfMatches)
            {
                bestMatches.Add(styler);
            }
        }
        return bestMatches.ToArray();
    }
}
