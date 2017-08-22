using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour 
{

	public void ToTreeFelling()
	{
		SceneManager.LoadScene("TreeFelling");
	}

	public void ToHomestead()
	{
		SceneManager.LoadScene("Homestead");
	}
}
