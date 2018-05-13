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
		MenuManager.currentMenuManager.CloseAllCanvases(true);
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Homestead");
		PlayerManager.SetSpawnLocation(currentSceneName, "Homestead");

		LoadingScreen.Instance.WaitForLoad();
	}

	public static void ToMainCabin()
	{
		MenuManager.currentMenuManager.CloseAllCanvases(true);
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("MainCabin");
		PlayerManager.SetSpawnLocation(currentSceneName, "MainCabin");
		
		LoadingScreen.Instance.WaitForLoad();
	}

	public static void ToWorkshop()
	{
		MenuManager.currentMenuManager.CloseAllCanvases(true);
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Workshop");
		PlayerManager.SetSpawnLocation(currentSceneName, "Workshop");
		
		LoadingScreen.Instance.WaitForLoad();
	}

	public static void ToForest()
	{
		MenuManager.currentMenuManager.CloseAllCanvases(true);
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Forest");
		PlayerManager.SetSpawnLocation(currentSceneName, "Forest");
		
		LoadingScreen.Instance.WaitForLoad();
	}

	public static void ToLumberYard()
	{
		MenuManager.currentMenuManager.CloseAllCanvases(true);
		currentSceneName = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("LumberYard");
		PlayerManager.SetSpawnLocation(currentSceneName, "LumberYard");
		
		LoadingScreen.Instance.WaitForLoad();
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
