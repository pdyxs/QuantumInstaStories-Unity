using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class EmotionStyler : ScriptableObject
{
    public QuantumEmotions.Emotion[] emotions;

    public Sprite emoticon;

    public AnimatorController quemoticon;

    [FormerlySerializedAs("postProcessingVolume")] 
    public PostProcessProfile postProcessingProfile;

    public string[] hashtags;

    public Color hashtagColour;

    public bool SupportsEffect(Type effectType)
    {
        if (effectType == typeof(EmojiEffect))
        {
            return emoticon != null;
        } 
        if (effectType == typeof(PostProcessingEffect))
        {
            return postProcessingProfile != null;
        }

        if (effectType == typeof(QuemojiEffect))
        {
            return quemoticon != null;
        }

        if (effectType == typeof(HashtagEffect))
        {
            return hashtags != null && hashtags.Length > 0;
        }

        return false;
    }
}
