using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiEffect : QuantumEffect
{


    public Emoji[] emojiPositions
    {
        get
        {
            if (_emojiPositions == null)
            {
                _emojiPositions = GetComponentsInChildren<Emoji>(true);
            }

            return _emojiPositions;
        }
    }
    private Emoji[] _emojiPositions;
    
    protected override void UpdateStyle(EmotionStyler[] oldStyles)
    {
        var positions = new List<Emoji>(emojiPositions);
        positions.Shuffle();
        
        Debug.Log($"Emoji! {positions.Count} {currentStyles.Length}");

        for (var i = 0; i != positions.Count; ++i)
        {
            if (i < currentStyles.Length)
            {
                positions[i].gameObject.SetActive(true);
                positions[i].svg.sprite = currentStyles[i].emoticon;
            }
            else
            {
                positions[i].gameObject.SetActive(false);
            }
        }
    }
}
