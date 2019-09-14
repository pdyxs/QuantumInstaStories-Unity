using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emojis : MonoSingleton<Emojis>
{
    protected override bool DestroyOnLoad => true;

    public Emoji[] emojis;
}
