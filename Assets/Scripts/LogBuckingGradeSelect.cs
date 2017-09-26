using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogBuckingGradeSelect : MonoBehaviour 
{
	public static LogBuckingGradeSelect LogBuckingUIRef;

	public Canvas GradeSelectCanvas;
	public Transform gradeTextGroup;

	public Color32 gradeEnabledColor;
	public Color32 gradeDisabledColor;

	void Start () 
	{
		LogBuckingUIRef = this;
	}
	
	void Update () 
	{
		
	}

	public void ToggleSelectionUI()
	{
		GradeSelectCanvas.enabled = !GradeSelectCanvas.enabled;

		if (GradeSelectCanvas.enabled) UpdateEnabledGrades();
	}

	public void MoveLeft()
	{
		if (gradeTextGroup.localPosition.x > -600) gradeTextGroup.localPosition = new Vector3(gradeTextGroup.localPosition.x - 150, 0, 0);
	}

	public void MoveRight()
	{
		if (gradeTextGroup.localPosition.x < 0) gradeTextGroup.localPosition = new Vector3(gradeTextGroup.localPosition.x + 150, 0, 0);
	}

	void UpdateEnabledGrades()
	{
		int[] gradeCounts = HomesteadStockpile.GetAllLogsCount();

		gradeTextGroup.GetChild(4).GetComponent<Text>().color = gradeCounts[0] > 0 ? gradeEnabledColor : gradeDisabledColor;
		gradeTextGroup.GetChild(3).GetComponent<Text>().color = gradeCounts[1] > 0 ? gradeEnabledColor : gradeDisabledColor;
		gradeTextGroup.GetChild(2).GetComponent<Text>().color = gradeCounts[2] > 0 ? gradeEnabledColor : gradeDisabledColor;
		gradeTextGroup.GetChild(1).GetComponent<Text>().color = gradeCounts[3] > 0 ? gradeEnabledColor : gradeDisabledColor;
		gradeTextGroup.GetChild(0).GetComponent<Text>().color = gradeCounts[4] > 0 ? gradeEnabledColor : gradeDisabledColor;
	}
}
