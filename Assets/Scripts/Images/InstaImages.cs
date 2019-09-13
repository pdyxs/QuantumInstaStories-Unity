using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class InstaImages : MonoBehaviour
{
	public InstaTimers timers;

	public InstaTimer timerPrefab;

	public InstaImage[] images;

	private int currentSelected = 0;

	private void Start()
	{
		images = GetComponentsInChildren<InstaImage>(true);

		var timerList = new List<InstaTimer>();
		for (var i = 0; i != images.Length; ++i)
		{
			images[i].gameObject.SetActive(i == 0);
			var newTimer = Instantiate(timerPrefab, timers.transform);
			timerList.Add(newTimer);
		}

		timers.timers = timerList.ToArray();
		timers.onChangeImage.AddListener(ChangeToImage);
	}

	private void ChangeToImage(int image)
	{
		images[currentSelected].gameObject.SetActive(false);
		currentSelected = image;
		images[currentSelected].gameObject.SetActive(true);
	}

	public void Next()
	{
		Debug.Log("hello");
		var next = Mathf.Min(currentSelected + 1, images.Length - 1);
		ChangeToImage(next);
		timers.SetTo(next);
	}

	public void Previous()
	{
		var prev = Mathf.Max(currentSelected - 1, 0);
		ChangeToImage(prev);
		timers.SetTo(prev);
	}
}
