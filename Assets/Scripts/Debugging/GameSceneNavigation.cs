using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneNavigation 
{
	private static int currentScene;
	private static string currentSceneName;

	public static void ToHomestead()
	{
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Homestead");
		PlayerManager.SetSpawnLocation(currentSceneName, "Homestead");
	}

	public static void ToMainCabin()
	{
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("MainCabin");
		PlayerManager.SetSpawnLocation(currentSceneName, "MainCabin");
	}

	public static void ToWorkshop()
	{
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Workshop");
		PlayerManager.SetSpawnLocation(currentSceneName, "Workshop");
	}

	public static void ToForest()
	{
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Forest");
		PlayerManager.SetSpawnLocation(currentSceneName, "Forest");
	}

	public static void ToLumberYard()
	{
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("LumberYard");
		PlayerManager.SetSpawnLocation(currentSceneName, "LumberYard");
	}
}
