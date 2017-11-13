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
		GameSceneNavigation.ToHomestead();
	}

	public void ToMainCabin()
	{
		ToMainCabinTrigger.CloseMenu();
		GameSceneNavigation.ToMainCabin();
	}

	public void ToWorkshop()
	{
		ToWorkshopTrigger.CloseMenu();
		GameSceneNavigation.ToWorkshop();
	}

	public void ToForest()
	{
		ToForestTrigger.CloseMenu();
		GameSceneNavigation.ToForest();
		//enabled ForestPlayerBehavior script on player object
	}
}
