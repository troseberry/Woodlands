using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class QualityMinigame : MonoBehaviour
{
	public Slider qualitySlider;
	private float swingValue = 0;

	// private bool gameEnabled = false;

	private static List<int> swingGrades = new List<int>();

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
		qualitySlider.value = Mathf.PingPong(Time.time, 1);
		 

		if (Input.GetMouseButtonDown(0))
		{
			swingValue = qualitySlider.value < 0.5f ?
			Mathf.Floor(qualitySlider.value * 100) / 100 : swingValue = qualitySlider.value != 0.5f ? 
			Mathf.Ceil(qualitySlider.value * 100) / 100 : 0.5f;


			// Debug.Log("Player Swing (Slider): " + qualitySlider.value);
			// Debug.Log("Player Swing (Rounded): " + swingValue);

			int gradeInt = FloatToGradeInt(swingValue, LoggingActivity.FELLING);

			Debug.Log("Player Swing (Grade): " + (QualityGrade)gradeInt);

			swingGrades.Add(gradeInt);
		}
	}

	int FloatToGradeInt(float swingVal, LoggingActivity activity)
	{
		switch (activity)
		{
			case LoggingActivity.FELLING:
				int toolTier = PlayerTools.GetToolByName(ToolName.FELLING_AXE).GetCurrentTier();
				return CompareToRanges(swingVal, toolTier);
		}
		return -1;
	}

	int CompareToRanges(float value, int toolTier)
	{
		int rangeIndex = 10 % ( (toolTier - 1) + 6);

		// Debug.Log("Range Index: " + rangeIndex);

		for (int i = 0; i < rangeIndex + 1; i++)
		{
			// Debug.Log("Compare Range Index: " + i);
			// Debug.Log("Compare (Lower): " + (value >= swingGradeRanges[i, 0]));
			// Debug.Log("Compare (Upper): " + (value <= swingGradeRanges[i, 1]));
			if (value >= swingGradeRanges[i, 0] && value <= swingGradeRanges[i, 1])
			{
				// Debug.Log("Returned Index: " + i);
				return i;
			}
		}
		return -1;
	}

	private static float[,] swingGradeRanges = new float[5,2]
	{
		{0.5f, 0.5f},	
		{0.49f, 0.51f},
		{0.48f, 0.52f},
		{0.47f, 0.53f},
		{0f, 1f},
	};

	public static int CalculateAverageGrade()
	{
		int avg = Mathf.RoundToInt( (float) swingGrades.Average());
		swingGrades.Clear();
		return avg;
	}
}
