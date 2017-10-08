using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayGradeUI : MonoBehaviour 
{
	public Canvas gradeSelectCanvas;
	private string grade;

	void Start () 
	{
		gradeSelectCanvas.enabled = false;
		grade = gradeSelectCanvas.gameObject.transform.GetChild(1).name;
	}
	
	void OnEnable () 
	{
		grade = gradeSelectCanvas.gameObject.transform.GetChild(1).name;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") gradeSelectCanvas.enabled = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") gradeSelectCanvas.enabled = false;
	}

	public string GetGradeString() { return grade; }

	public void HideUI()
	{
		gradeSelectCanvas.enabled = false;
	}
}