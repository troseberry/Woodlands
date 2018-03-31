using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnScene {HOMESTEAD, MAIN_CABIN, WORKSHOP, FOREST, LUMBER_YARD, NONE}
public class SpawnLocations 
{
	//naming convention: currentScene_destinationScene

	//homestead_homestead
	private static Vector3 homestead_mainCabin = new Vector3(1f, 0, -4f);
	private static Vector3 homestead_workshop = new Vector3(0.25f, 0, -2.5f);
	private static Vector3 homestead_forest = new Vector3(35f, 1.5f, 5f);
	private static Vector3 homestead_lumberYard = new Vector3(-17.5f, 0, -2.5f);


	private static Vector3 mainCabin_homestead = new Vector3(-0.5f, 0, 7.5f);
	//mainCabin_mainCabin
	//mainCabin_workshop
	//mainCabin_forest
	//mainCabin_lumberYard

	private static Vector3 workshop_homestead = new Vector3(10f, 0, 8.5f);
	//workshop_mainCabin
	//workshop_workshop
	//workshop_forest
	//workshop_lumberYard

	private static Vector3 forest_homestead = new Vector3(-21f, 0, 6f);
	//forest_mainCabin
	//forest_workshop
	//forest_forest
	//forest_lumberYard

	private static Vector3 lumberYard_homestead = new Vector3(22f, 0, 6f);
	//lumberYard_mainCabin
	//lumberYard_workshop
	//lumberYard_forest
	//lumberYard_lumberYard

	private static Vector3 sleepSpawnLocation = new Vector3(-4.5f, 4f, -1f);

	private static Vector3[,] spawnLocationsArray = new Vector3[5,5]
	{
		{Vector3.zero, homestead_mainCabin, homestead_workshop, homestead_forest, homestead_lumberYard},
		{mainCabin_homestead, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero},
		{workshop_homestead, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero},
		{forest_homestead, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero},
		{lumberYard_homestead, Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero},
	};


	public static Vector3 ReturnSpawnVector(int start, int destination)
	{
		return spawnLocationsArray[start, destination];
	}

	public static SpawnScene ParseString(string sceneName)
	{
		switch (sceneName)
		{
			case "Homestead":
				return SpawnScene.HOMESTEAD;
			case "MainCabin":
				return SpawnScene.MAIN_CABIN;
			case "Workshop":
				return SpawnScene.WORKSHOP;
			case "Forest":
				return SpawnScene.FOREST;
			case "LumberYard":
				return SpawnScene.LUMBER_YARD;
		}
		return SpawnScene.NONE;
	}

	public static Vector3 GetSpawnForLoad(string lastSceneName)
	{
		switch (lastSceneName)
		{
			case "Homestead":
				return mainCabin_homestead;
			case "MainCabin":
				return homestead_mainCabin;
			case "Workshop":
				return homestead_workshop;
			case "Forest":
				return homestead_forest;
			case "LumberYard":
				return homestead_lumberYard;
			case "MainMenu":
				return sleepSpawnLocation;
		}
		return new Vector3(0, 0, 0);
	}
}
