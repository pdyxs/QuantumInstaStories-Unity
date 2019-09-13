using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuantumEffect : MonoBehaviour
{
    public EmotionStyler[] currentStyles { get; private set; } = { };
    
    public void SetTo(EmotionStyler[] styles)
    {
        var oldStyles = currentStyles;
        currentStyles = (EmotionStyler[])styles.Clone();
        UpdateStyle(oldStyles);
    }

    protected abstract void UpdateStyle(EmotionStyler[] oldStyles);
}
