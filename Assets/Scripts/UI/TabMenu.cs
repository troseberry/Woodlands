using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabMenu : MonoBehaviour 
{
	public GameObject menuObject;
	private bool menuOpen = false;
	private bool doMove = false;

	private float moveTime = 0f;
	Vector3 openPosition = new Vector3(-665, 0, 0);
	Vector3 closedPosition = new Vector3(-1265, 0, 0);

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Tab Menu"))
		{
			doMove = true;
		}

		if (doMove)
		{
			if (!menuOpen)
			{
				StartCoroutine(OpenMenu());
			}
			else
			{
				StartCoroutine(CloseMenu());
			}
		}
	}

	IEnumerator OpenMenu()
	{
		moveTime += Time.deltaTime/0.15f;
		menuObject.transform.localPosition = Vector3.Lerp(closedPosition, openPosition, moveTime);

		if(menuObject.transform.localPosition.x >= -715)
		{
			moveTime = 0f;
			menuOpen = true;
			doMove = false;
		}
		yield return null;
		
	}

	IEnumerator CloseMenu()
	{
		moveTime += Time.deltaTime/0.15f;
		menuObject.transform.localPosition = Vector3.Lerp(openPosition, closedPosition, moveTime);

		if(menuObject.transform.localPosition.x <= -1215)
		{
			moveTime = 0f;
			menuOpen = false;
			doMove = false;
		}
		yield return null;
	}
}