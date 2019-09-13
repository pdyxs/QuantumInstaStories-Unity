using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(QuantumEmotions))]
public class InstaImage : MonoBehaviour {

	public QuantumEmotions emotions
	{
		get
		{
			if (_emotions == null)
			{
				_emotions = GetComponent<QuantumEmotions>();
			}

			return _emotions;
		}
	}
	private QuantumEmotions _emotions;

	public QuantumEffect[] effects
	{
		get
		{
			if (_effects == null)
			{
				_effects = GetComponentsInChildren<QuantumEffect>(true);
			}

			return _effects;
		}
	}
	private QuantumEffect[] _effects;

	public void Initialise(float time)
	{
		var timeSoFar = 0f;
		foreach (var emotionalState in emotions.states)
		{
			var stateTime = emotionalState.probability * time;
			TimeUtils.RunAfter(() =>
			{
				foreach (var effect in effects)
				{
					var stylers = QuantumStylers.instance.GetMatchingStylers(emotionalState.Emotions(emotions), effect.GetType());
					effect.SetTo(stylers);
				}
			}, timeSoFar);
			timeSoFar += stateTime;
		}
	}

	public void TearDown()
	{
		
	}
}
