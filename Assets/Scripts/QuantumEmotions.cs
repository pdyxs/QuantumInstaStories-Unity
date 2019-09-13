using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumEmotions : MonoBehaviour
{
    public enum Emotion
    {
        Anger,
        Contempt,
        Disgust,
        Fear,
        Happiness,
        Neutral,
        Sadness,
        Surprise
    }
    
    [Serializable]
    public class EmotionState
    {
        public bool[] emotions;
        public float probability;

        public Emotion[] Emotions(QuantumEmotions parent)
        {
            var ret = new List<Emotion>();
            for (var i = 0; i != emotions.Length; ++i)
            {
                if (emotions[i])
                {
                    ret.Add(parent.emotions[i]);
                }
            }

            return ret.ToArray();
        }
    }

    public List<Emotion> emotions = new List<Emotion>();

    public List<EmotionState> states = new List<EmotionState>();
}
