using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuemojiEffect : QuantumEffect
{
    protected override void UpdateStyle(EmotionStyler[] oldStyles)
    {
        if (currentStyles.Length == 0)
        {
            Quemoji.instance.Image.enabled = false;
        }
        else
        {
            Quemoji.instance.Image.enabled = true;
            Quemoji.instance.SetTo(currentStyles[0].quemoticon);
        }
    }
}
