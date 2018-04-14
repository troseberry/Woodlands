using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	public static LoadingScreen Instance;

	private static bool loadingScreenExists = false;
	private Canvas loadingScreenCanvas;

	private static bool isLoading = false;

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

	void Update()
	{
		DebugPanel.Log("Is Loading: ", "Loading", isLoading);
	}

	public void WaitForLoad()
	{
		StartCoroutine(WaitForLoadToFinish());
	}

	IEnumerator WaitForLoadToFinish()
	{
		yield return new WaitUntil( () => PlayerManager.currentSceneSaveHandler.HasFinishedLoading());

		yield return new WaitForSeconds(0.5f);

		CharacterInputController.ToggleCharacterInput(true);
		CharacterInputController.ToggleCameraInput(true);

		loadingScreenCanvas.enabled = false;
		isLoading = false;
	}


	public void ToggleLoadingCanvas(bool state)
	{
		loadingScreenCanvas.enabled = state;
	}


	public static void ToggleIsLoading(bool state) { isLoading = state; }

	public static bool IsLoading() { return isLoading; }
}
