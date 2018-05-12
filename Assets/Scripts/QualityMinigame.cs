using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class QualityMinigame : MonoBehaviour
{
	public static QualityMinigame Instance;

	public Slider qualitySlider;

	private static bool gameStarted = false;
	private static bool sliderLeft = true;

	private float swingValue = 0;
	private static List<int> swingGrades = new List<int>();

	private static float timer = 0f;
	private float moveDuration = 1f;
	private static float moveSpeed;
	
	private static int ungradedFirewood = 0;
	private static QualityGrade lastMaxFirewoodGrade;

	void Start ()
	{
		Instance = this;
		
		// qualitySlider.value = 0f;
		// timer = 0f;
	}

	void OnEnable()
	{
		if (Instance == null) Instance = this;

		// qualitySlider.value = 0f;
		// timer = 0f;
	}
	
	void Update ()
	{
		if (gameStarted)
		{
			if (timer <  moveDuration)
			{
				timer += (Time.deltaTime/moveDuration); //*moveSpeed

				if (sliderLeft) qualitySlider.value = Mathf.Lerp(0f, 1f, timer);
			}
			else if (timer >= moveDuration)
			{
				sliderLeft = false;
				GetGradeFromSliderValue();
			}
			
			if (Input.GetMouseButtonDown(0) && sliderLeft)
			{
				GetGradeFromSliderValue();
			}
		}
	}

	void GetGradeFromSliderValue()
	{
		swingValue = qualitySlider.value < 0.5f ?
		Mathf.Floor(qualitySlider.value * 100) / 100 : swingValue = qualitySlider.value != 0.5f ? 
		Mathf.Ceil(qualitySlider.value * 100) / 100 : 0.5f;
		
		int gradeInt = FloatToGradeInt(swingValue, LoggingActivityPlayerBehavior.GetCurrentActivity());

		swingGrades.Add(gradeInt);

		// Debug.Log("Player Swing (Slider): " + qualitySlider.value);
		// Debug.Log("Player Swing (Rounded): " + swingValue);
		// Debug.Log("Player Swing (Grade): " + (QualityGrade)gradeInt);
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
		// Debug.Log("Average: " + avg + " | Count: " + swingGrades.Count);
		swingGrades.Clear();

		EndGame();

		return avg;
	}

	public static int CalculateAverageGrade(int remainingLogs)
	{
		int avg = Mathf.RoundToInt( (float) swingGrades.Average());
		// Debug.Log("Average: " + avg + " | Count: " + swingGrades.Count);
		swingGrades.Clear();

		if (remainingLogs == 1) EndGame();

		return avg;
	}

	public static void StartGame() { if (!gameStarted) Instance.StartCoroutine(Instance.DelayGameStart(0.5f)); }

	IEnumerator DelayGameStart(float delay)
	{
		yield return new WaitForSeconds(delay);
		gameStarted = true;
	}

	public static void EndGame()
	{
		Instance.qualitySlider.value = 0f;
		gameStarted = false;
		timer = 0f;
		sliderLeft = true;
	}

	public static bool IsGradeListEmpty() { return swingGrades.Count == 0; }

	public static void SetUngradedFirewood(int value) { ungradedFirewood = value; }

	public static void IncrementUngradedFirewood() { ungradedFirewood += 2; }

	public static int GetUngradedFirewood() { return ungradedFirewood; }

	public static void ClearUngradedFirewood() { ungradedFirewood = 0; }

	public static void SetLastMaxFirewoodGrade(QualityGrade grade) { lastMaxFirewoodGrade = grade; }
	
	public static QualityGrade GetLastMaxFirewoodGrade() { return lastMaxFirewoodGrade; }
}
