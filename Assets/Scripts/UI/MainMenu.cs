using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

	public void StartNewGame()
	{
		
	}

	public void LoadGame()
	{
		// Load Save Data
		SceneManager.LoadScene("MainCabin");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}