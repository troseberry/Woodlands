﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations 
{
	//naming convention: currentScene_destinationScene

	//homestead_homestead
	private static Vector3 homestead_mainCabin = new Vector3(2.75f, 0, -5);
	private static Vector3 homestead_workshop = new Vector3(0, 0, -1.5f);
	private static Vector3 homestead_forest = new Vector3(32.5f, 2, 5.75f);
	private static Vector3 homestead_lumberYard = new Vector3(-14.5f, 0, -4.5f);


	private static Vector3 mainCabin_homestead = new Vector3(-2.5f, 0, 8);
	//mainCabin_mainCabin
	//mainCabin_workshop
	//mainCabin_forest
	//mainCabin_lumberYard

	private static Vector3 workshop_homestead = new Vector3(10, 0, 9);
	//workshop_mainCabin
	//workshop_workshop
	//workshop_forest
	//workshop_lumberYard

	private static Vector3 forest_homestead = new Vector3(-20, 0, 2);
	//forest_mainCabin
	//forest_workshop
	//forest_forest
	//forest_lumberYard

	private static Vector3 lumberYard_homestead = new Vector3(20, 0, 2);
	//lumberYard_mainCabin
	//lumberYard_workshop
	//lumberYard_forest
	//lumberYard_lumberYard


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
}
