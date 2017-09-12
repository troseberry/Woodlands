using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneNavigation 
{
	private static int currentScene;

	public static void ToHomestead()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("Homestead");
		PlayerManager.SetSpawnLocation(currentScene, 0);
	}

	public static void ToMainCabin()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("MainCabin");
		PlayerManager.SetSpawnLocation(currentScene, 1);
	}

	public static void ToWorkshop()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("Workshop");
		PlayerManager.SetSpawnLocation(currentScene, 2);
	}

	public static void ToForest()
	{
		currentScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("Forest");
		PlayerManager.SetSpawnLocation(currentScene, 3);
	}

	// static void HandleSpawning(int destinationScene)
	// {
	// 	// 0 - 4: homestead, maincabin, workshop, forest
	// 	currentScene = SceneManager.GetActiveScene().buildIndex;
	// 	PlayerManager.SetSpawnLocation(currentScene, destinationScene);
	// }
}
