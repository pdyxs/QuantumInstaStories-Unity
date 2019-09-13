using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EmotionStyler : ScriptableObject
{
    public QuantumEmotions.Emotion[] emotions;

    public Sprite emoticon;

    public bool SupportsEffect(Type effectType)
    {
        if (effectType == typeof(EmojiEffect))
        {
            return emoticon != null;
        }

        return false;
    }
}
