using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InstaTimers : MonoBehaviour
{

	public float totalTime = 10;

	private float timeSoFar = 0;

	public bool paused = false;

	public InstaTimer[] timers;

	private int currentSelection = 0;
	
	public class TimerEvent : UnityEvent<int> {}

	public TimerEvent onChangeImage = new TimerEvent();

	private void Update()
	{
		timeSoFar += Time.deltaTime;

		if (timers.Length == 0) return; 
		
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
				onChangeImage.Invoke(currentSelection);
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

	public void SetTo(int i)
	{
		if (i > currentSelection)
		{
			timers[currentSelection].ChangeTimer(1);
		}
		else
		{
			timers[currentSelection].ChangeTimer(0);
		}
		timeSoFar = 0;
		currentSelection = i;
	}
}
