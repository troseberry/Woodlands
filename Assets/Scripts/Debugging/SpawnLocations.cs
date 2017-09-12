using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations 
{
	//naming convention: currentScene_destinationScene

	//homestead_homestead
	private static Vector3 homestead_mainCabin = new Vector3(1, 0, -10);
	private static Vector3 homestead_workshop;
	private static Vector3 homestead_forest;


	private static Vector3 mainCabin_homestead;
	//mainCabin_mainCabin
	//mainCaib_workshop
	//mainCabin_forest

	private static Vector3 workshop_homestead;
	//workshop_mainCabin
	//workshop_workshop
	//workshop_forest

	private static Vector3 forest_homestead;
	//forest_mainCabin
	//forest_workshop
	//forest_forest


	private static Vector3[,] spawnLocationsArray = new Vector3[4,4]
	{
		{Vector3.zero, homestead_mainCabin, homestead_workshop, homestead_forest},
		{mainCabin_homestead, Vector3.zero, Vector3.zero, Vector3.zero},
		{workshop_homestead, Vector3.zero, Vector3.zero, Vector3.zero},
		{forest_homestead, Vector3.zero, Vector3.zero, Vector3.zero}
	};


	public static Vector3 ReturnSpawnVector(int start, int destination)
	{
		return spawnLocationsArray[start, destination];
	}
}
