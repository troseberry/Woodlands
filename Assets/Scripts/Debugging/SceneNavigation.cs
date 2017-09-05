using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneNavigation 
{

	public static void ToHomestead()
	{
		SceneManager.LoadScene("Homestead");
	}

	public static void ToForest()
	{
		SceneManager.LoadScene("Forest");
	}
}
