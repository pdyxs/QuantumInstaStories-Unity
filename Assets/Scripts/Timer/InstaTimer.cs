using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaTimer : MonoBehaviour
{

	public RectTransform myTransform;

	public void ChangeTimer(float amount)
	{
		myTransform.anchorMax = new Vector2(amount, myTransform.anchorMax.y);
	}
}
