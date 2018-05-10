using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityMetronome : MonoBehaviour 
{
	public static QualityMetronome Instance;

	public Slider qualitySlider;
	public static float sliderValue;
	private float swingValue = 0f;

	private static bool gameStarted = false;

	public static float timer = 0f;

	private float moveDuration = 1f;
	private static float moveSpeed;

	private static bool sliderLeft = true;

	void Start () 
	{
		Instance = this;

		qualitySlider.value = 0;
		timer = 0f;
	}
	
	void Update () 
	{
		if (timer < moveDuration)
		{
			timer += Time.deltaTime/moveDuration * 1.5f;

			if (sliderLeft) qualitySlider.value = Mathf.Lerp(0f, 1f, timer);
			else qualitySlider.value = Mathf.Lerp(1f, 0f, timer);
		}
		else
		{
			sliderLeft = !sliderLeft;
			timer = 0;
		}
	}

}
