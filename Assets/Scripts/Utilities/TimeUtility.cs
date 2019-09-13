using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;

public class TimeUtility : MonoSingleton<TimeUtility>
{
    public void RunAfter(Action action, float time)
    {
        DoStartCoroutine(RunAfterDelay(action, time));
    }

    private IEnumerator RunAfterDelay(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }

    public void RunAfterFrame(Action action)
    {
        RunAfterFrames(action, 1);
    }

    public void RunAfterFrames(Action action, int frames)
    {
        DoStartCoroutine(runAfterFrames(action, frames));
    }

    private IEnumerator runAfterFrames(Action action, int frames)
    {
        for (var i = 0; i < frames; ++i)
        {
            yield return false;
        }
        action.Invoke();
    }

    private void DoStartCoroutine(IEnumerator coroutine)
    {
#if UNITY_EDITOR
        if (!Application.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            StartEditorCoroutine(coroutine);
            return;
        }
#endif
        StartCoroutine(coroutine);
    }

    [HideInInspector]
    public UnityEvent OnUpdate = new UnityEvent();

    private void Update()
    {
        OnUpdate.Invoke();
    }

    public static void ListenToUpdate(UnityAction action) => instance.OnUpdate.AddListener(action);
    public static void StopListeningToUpdate(UnityAction action) => instance.OnUpdate.RemoveListener(action);
    
#if UNITY_EDITOR
    // This is my callable function
    public static IEnumerator StartEditorCoroutine(IEnumerator newCoroutine)
    {
        CoroutineInProgress.Add(newCoroutine);
        return newCoroutine;
    }
    /// <summary>
    ///  Coroutine to execute. Manage by the EasyLocalization_script
    /// </summary>
    private static List<IEnumerator> CoroutineInProgress = new List<IEnumerator>();
    
    [InitializeOnLoadMethod]
    private static void InitialiseEditor()
    {
        EditorApplication.update += ExecuteCoroutine;
    }
 
    static int currentExecute = 0;
    private static void ExecuteCoroutine()
    {
        if (CoroutineInProgress.Count <= 0)
        {
            return;
        }
 
        currentExecute = (currentExecute + 1) % CoroutineInProgress.Count;
         
        bool finish = !CoroutineInProgress[currentExecute].MoveNext();
 
        if (finish)
        {
            CoroutineInProgress.RemoveAt(currentExecute);
        }
    }
#endif
}

public static class TimeUtils
{
    public static void RunAfter(this Action action, float time)
    {
        TimeUtility.instance.RunAfter(action, time);
    }
    
    public static void RunAfter(this UnityEvent action, float time)
    {
        TimeUtility.instance.RunAfter(action.Invoke, time);
    }
    
    public static void RunAfterFrames(this Action action, int frames)
    {
        TimeUtility.instance.RunAfterFrames(action, frames);
    }
    
    public static void RunAfterFrames(this UnityEvent action, int frames)
    {
        TimeUtility.instance.RunAfterFrames(action.Invoke, frames);
    }
    
    public static void RunAfterFrame(this Action action)
    {
        TimeUtility.instance.RunAfterFrame(action);
    }
    
    public static void RunAfterFrame(this UnityEvent action)
    {
        TimeUtility.instance.RunAfterFrame(action.Invoke);
    }
}
