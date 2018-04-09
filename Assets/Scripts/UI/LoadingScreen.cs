using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	public static LoadingScreen Instance;

	bool loadingScreenExists = false;
	private Canvas loadingScreenCanvas;

	void Awake()
	{
		if (!loadingScreenExists)
		{
			DontDestroyOnLoad(gameObject);
			loadingScreenExists = true;
		}
		else
		{
			Destroy(gameObject);
		}	
	}

	void Start()
	{
		Instance = this;
		loadingScreenCanvas = GetComponent<Canvas>();
	}

	public void WaitForLoad()
	{
		StartCoroutine(WaitForLoadToFinish());
	}

	IEnumerator WaitForLoadToFinish()
	{
		yield return new WaitUntil( () => PlayerManager.currentSceneSaveHandler.HasFinishedLoading());

		yield return new WaitForSeconds(2f);

		CharacterInputController.ToggleCharacterInput(true);
		CharacterInputController.ToggleCameraInput(true);

		loadingScreenCanvas.enabled = false;
	}


	public void ToggleLoadingCanvas(bool state)
	{
		loadingScreenCanvas.enabled = state;
	}
}
