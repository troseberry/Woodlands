using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour 
{
	public KeyItemInteract ToHomesteadTrigger;
	public KeyItemInteract ToMainCabinTrigger;
	public KeyItemInteract ToWorkshopTrigger;
	public KeyItemInteract ToForestTrigger;

	public void ToHomestead()
	{
		ToHomesteadTrigger.CloseMenu();
		SceneNavigation.ToHomestead();
	}

	public void ToMainCabin()
	{
		ToMainCabinTrigger.CloseMenu();
		SceneNavigation.ToMainCabin();
	}

	public void ToWorkshop()
	{
		ToWorkshopTrigger.CloseMenu();
		SceneNavigation.ToWorkshop();
	}

	public void ToForest()
	{
		ToForestTrigger.CloseMenu();
		SceneNavigation.ToForest();
	}
}
