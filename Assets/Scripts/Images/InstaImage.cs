using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using TinyJson;
using UnityEngine;
using UnityEngine.UI;

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

	public Image actualImage;

	public void Setup(Sprite sprite, InstaImageState state)
	{
		actualImage.sprite = sprite;
		emotions.emotions.Clear();
		emotions.states.Clear();
		foreach (var request in state.requests)
		{
			if (request.hamiltonian.Length == 0)
			{
				emotions.emotions.AddRange(request.emotions);
				var estate = new QuantumEmotions.EmotionState
				{
					emotions = Enumerable.Repeat(true, request.emotions.Length).ToList()
				};
				emotions.states.Add(estate);
			}
			else
			{
				QiskitClient.instance.SendRequest(request, this);
			}
		}
	}

	public void RecieveResults(QiskitRequest request, string results)
	{
		results = results.Replace('\'', '"');
		var stringDict = JSONParser.FromJson<Dictionary<string, float>>(results);

		var emotionBits = new List<int>();
		foreach (var emotion in request.emotions)
		{
			var bit = emotions.emotions.IndexOf(emotion);
			if (bit < 0)
			{
				bit = emotions.emotions.Count;
				emotions.emotions.Add(emotion);

				foreach (var state in emotions.states)
				{
					state.emotions.Add(false);
				}
			}
			emotionBits.Add(bit);
		}

		foreach (var entry in stringDict)
		{
			if (entry.Value == 0) continue;
			if (!entry.Key.Contains('1')) continue;
			
			var state = new QuantumEmotions.EmotionState();
			state.emotions = new List<bool>(new bool[emotions.emotions.Count]);
			
			for (var i = 0; i != entry.Key.Length; ++i)
			{
				var index = emotionBits[i];
				state.emotions[index] = (entry.Key[i] == '1');
			}

			state.probability = entry.Value;
			
			emotions.states.Add(state);
		}
	}

	public void Initialise(float time)
	{
		var timeSoFar = 0f;
		var totalProbability = emotions.states.Sum(e => e.probability);
		foreach (var emotionalState in emotions.states)
		{
			var stateTime = emotionalState.probability * time / totalProbability;
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
