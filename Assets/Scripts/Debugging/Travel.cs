using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour 
{

	public void ToForest()
	{
		SceneNavigation.ToForest();
	}
	
	public void ToHomestead()
	{
		SceneNavigation.ToHomestead();
	}

	public void ToMainCabin()
	{
		SceneNavigation.ToMainCabin();
	}

	public void ToWorkshop()
	{
		SceneNavigation.ToWorkshop();
	}
}
