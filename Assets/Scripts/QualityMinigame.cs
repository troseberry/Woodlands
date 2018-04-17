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


	void OnEnabled()
	{
		//get current logging activity here instead of in update
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

			int gradeInt = FloatToGradeInt(swingValue, LoggingActivityPlayerBehavior.GetCurrentActivity());

			Debug.Log("Player Swing (Grade): " + (QualityGrade)gradeInt);

			swingGrades.Add(gradeInt);
		}
	}

	int FloatToGradeInt(float swingVal, LoggingActivity activity)
	{
		int returnValue = -1;
		int toolTier = 0;

		if (activity == LoggingActivity.FELLING)
		{
			toolTier = PlayerTools.GetToolByName(ToolName.FELLING_AXE).GetCurrentTier();
		}
		else if (activity == LoggingActivity.BUCKING)
		{
				toolTier = PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW).GetCurrentTier();
		}
		else if (activity == LoggingActivity.SPLITTING)
		{
			toolTier = PlayerTools.GetToolByName(ToolName.SPLITTING_AXE).GetCurrentTier();
		}
		returnValue = CompareToRanges(swingVal, toolTier);
		return returnValue;
	}

	int CompareToRanges(float value, int toolTier)
	{
		int rangeIndex = toolTier - 1;

		// Debug.Log("Range Index: " + rangeIndex);

		for (int i = 4; i > rangeIndex - 1; i--)
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
		// Debug.Log("Returned Range Index");
		return rangeIndex;
	}

	private static float[,] swingGradeRanges = new float[5,2]
	{
		{0f, 1f},
		{0.47f, 0.53f},
		{0.48f, 0.52f},
		{0.49f, 0.51f},
		{0.5f, 0.5f},	
	};

	public static int CalculateAverageGrade()
	{
		int avg = Mathf.RoundToInt( (float) swingGrades.Average());
		Debug.Log("Average: " + avg);
		swingGrades.Clear();
		return avg;
	}
}
