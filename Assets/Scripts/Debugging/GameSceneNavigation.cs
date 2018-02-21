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
		MenuManager.currentMenuManager.CloseAllCanvases();
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Homestead");
		PlayerManager.SetSpawnLocation(currentSceneName, "Homestead");
	}

	public static void ToMainCabin()
	{
		MenuManager.currentMenuManager.CloseAllCanvases();
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("MainCabin");
		PlayerManager.SetSpawnLocation(currentSceneName, "MainCabin");
	}

	public static void ToWorkshop()
	{
		MenuManager.currentMenuManager.CloseAllCanvases();
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Workshop");
		PlayerManager.SetSpawnLocation(currentSceneName, "Workshop");
	}

	public static void ToForest()
	{
		MenuManager.currentMenuManager.CloseAllCanvases();
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Forest");
		PlayerManager.SetSpawnLocation(currentSceneName, "Forest");
	}

	public static void ToLumberYard()
	{
		MenuManager.currentMenuManager.CloseAllCanvases();
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("LumberYard");
		PlayerManager.SetSpawnLocation(currentSceneName, "LumberYard");
	}

	public static void ToTopFloor()
	{
		PlayerManager.TraverseStairs(true);
	}

	public static void ToBottomFloor()
	{
		PlayerManager.TraverseStairs(false);
	}
}
