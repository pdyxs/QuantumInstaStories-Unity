using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingManager : MonoSingleton<PostProcessingManager>
{
    protected override bool DestroyOnLoad => true;

    private Dictionary<PostProcessProfile, PostProcessVolume> _volumes = new Dictionary<PostProcessProfile, PostProcessVolume>();

    private void Start()
    {
        foreach (var volume in GetComponentsInChildren<PostProcessVolume>(true))
        {
            if (volume.sharedProfile != null)
                _volumes[volume.sharedProfile] = volume;
        }
    }

    public PostProcessVolume GetVolume(PostProcessProfile profile)
    {
        if (profile != null && _volumes.ContainsKey(profile))
        {
            return _volumes[profile];
        }

        return null;
    }
}
