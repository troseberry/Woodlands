using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class QualityMinigame : MonoBehaviour
{
	public static QualityMinigame Instance;

	public Slider qualitySlider;
	public static float sliderValue;
	private float swingValue = 0;

	private static bool gameStarted = false;

	private static List<int> swingGrades = new List<int>();

	public static float timer = 0f;

	private float moveDuration = 1f;
	private static float moveSpeed;

	private static bool sliderLeft = true;
	// private static bool playerDidInput = false;
	private static int ungradedFirewood = 0;
	private static QualityGrade lastMaxFirewoodGrade;

	void Start ()
	{
		Instance = this;
		
		qualitySlider.value = 0f;
		timer = 0f;
	}


	void OnEnabled()
	{
		//get current logging activity here instead of in update
		qualitySlider.value = 0f;
		timer = 0f;
	}
	
	void Update ()
	{
		if (gameStarted)
		{
			if (timer <  moveDuration)
			{
				timer += (Time.deltaTime/moveDuration);

				if (sliderLeft) qualitySlider.value = Mathf.Lerp(0f, 1f, timer);
				else qualitySlider.value = Mathf.Lerp(1f, 0f, timer);
			}
			else if (timer >= moveDuration)
			{
				sliderLeft = !sliderLeft;
				timer = 0f;

				// if (sliderLeft) playerDidInput = false;
			}
			

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
				// playerDidInput = true;
			}
		}

		// DebugPanel.Log("Timer", "Quality Game", timer);
		// DebugPanel.Log("Player Did Input", "Quality Game", playerDidInput);
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
		Debug.Log("Average: " + avg + " | Count: " + swingGrades.Count);
		swingGrades.Clear();

		Instance.qualitySlider.value = 0f;
		gameStarted = false;
		sliderLeft = true;
		timer = 0f;

		return avg;
	}

	public static int CalculateAverageGrade(int remainingLogs)
	{
		int avg = Mathf.RoundToInt( (float) swingGrades.Average());
		Debug.Log("Average: " + avg + " | Count: " + swingGrades.Count);
		swingGrades.Clear();

		if (remainingLogs == 1)
		{
			Instance.qualitySlider.value = 0f;
			gameStarted = false;
			sliderLeft = true;
			timer = 0f;
		}

		return avg;
	}

	public static void StartGame() { if (!gameStarted) gameStarted = true; }

	public static void SetSliderValue(float value) { sliderValue = value;}

	public static bool IsGradeListEmpty() { return swingGrades.Count == 0; }

	// public static void ResetPlayerDidInput() { playerDidInput = false; }

	// public static void BackFillSwingGrades(int totalNeeded)
	// {
	// 	Debug.Log("Before Backfill: " + swingGrades.Count);
	// 	int toFill = totalNeeded - swingGrades.Count;

	// 	for (int i = 0; i < toFill; i++)
	// 	{
	// 		swingGrades.Add(Instance.FloatToGradeInt(1f, LoggingActivityPlayerBehavior.GetCurrentActivity()));
	// 	}
	// 	Debug.Log("After Backfill: " + swingGrades.Count);
	// }

	public static void SetMoveSpeed(LoggingActivity activity) 
	{
		if (activity == LoggingActivity.FELLING) moveSpeed = 1.6f;
		else if (activity == LoggingActivity.BUCKING) moveSpeed = 2f;
		else if (activity == LoggingActivity.SPLITTING) moveSpeed = 1.15f;
	}

	public static void SetUngradedFirewood(int value) { ungradedFirewood = value; }

	public static void IncrementUngradedFirewood() { ungradedFirewood += 2; }

	public static int GetUngradedFirewood()
	{
		return ungradedFirewood;
	}

	public static void ClearUngradedFirewood() { ungradedFirewood = 0; }

	public static void SetLastMaxFirewoodGrade(QualityGrade grade) { lastMaxFirewoodGrade = grade; }
	
	public static QualityGrade GetLastMaxFirewoodGrade() { return lastMaxFirewoodGrade; }
}
