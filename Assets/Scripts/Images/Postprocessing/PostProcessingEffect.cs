using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessingEffect : QuantumEffect
{
    

    protected override void UpdateStyle(EmotionStyler[] oldStyles)
    {
        foreach (var style in oldStyles)
        {
            var volume = PostProcessingManager.instance.GetVolume(style.postProcessingProfile);
            if (volume != null)
            {
                volume.gameObject.SetActive(false);
            }
        }

        foreach (var style in currentStyles)
        {
            var volume = PostProcessingManager.instance.GetVolume(style.postProcessingProfile);
            if (volume != null)
            {
                volume.gameObject.SetActive(true);
            }
        }
        
    }
}
