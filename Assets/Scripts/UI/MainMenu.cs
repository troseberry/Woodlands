using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	void Start()
	{
		Debug.Log("Save Data Here: " + Application.persistentDataPath);
	}

	public void StartNewGame()
	{
		
	}

	public void LoadGame()
	{
		SaveLoad.Load();
		SceneManager.LoadScene("MainCabin");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}