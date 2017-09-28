using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocations 
{
	//naming convention: currentScene_destinationScene

	//homestead_homestead
	private static Vector3 homestead_mainCabin = new Vector3(2.75f, 0, -5);
	private static Vector3 homestead_workshop = new Vector3(0, 0, -1.5f);
	private static Vector3 homestead_forest = new Vector3(0, 0, -8);


	private static Vector3 mainCabin_homestead = new Vector3(-2.5f, 0, 8);
	//mainCabin_mainCabin
	//mainCabin_workshop
	//mainCabin_forest

	private static Vector3 workshop_homestead = new Vector3(-11, 0, 4);
	//workshop_mainCabin
	//workshop_workshop
	//workshop_forest

	private static Vector3 forest_homestead = new Vector3(-28, 0, 2);
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
