using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InstaTimers : MonoBehaviour
{

	public float totalTime = 10;

	private float timeSoFar = 0;

	public bool paused = false;

	public InstaTimer[] timers;

	private int currentSelection = 0;

	private void Start()
	{
		timers = GetComponentsInChildren<InstaTimer>().ToArray();
	}

	private void Update()
	{
		timeSoFar += Time.deltaTime;
		if (timeSoFar < totalTime)
		{
			timers[currentSelection].ChangeTimer(timeSoFar / totalTime);
		}
		else 
		{
			timers[currentSelection].ChangeTimer(1);
			if (currentSelection + 1 < timers.Length)
			{
				currentSelection++;
				timeSoFar = 0;
			}
		}
	}

	public void Pause()
	{
		paused = true;
	}

	public void Unpause()
	{
		paused = true;
	}

	public void ResetTimer()
	{
		timeSoFar = 0;
	}
}
