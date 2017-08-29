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

	public static void ToTreeFelling()
	{
		SceneManager.LoadScene("TreeFelling");
	}

	public static void ToLogBucking()
	{
		SceneManager.LoadScene("LogBucking");
	}

	public static void ToLogSplitting()
	{
		SceneManager.LoadScene("LogSplitting");
	}
}
