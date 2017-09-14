using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour 
{
	private static bool playerCreated;
	private static Transform playerTransform;
	

	void Awake()
	{
		if (!playerCreated)
		{
			DontDestroyOnLoad(gameObject);
			playerCreated = true;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start () 
	{
		playerTransform = this.transform;
		//eventually, load save data

		PlayerTools.AddTool(new Tool(ToolName.FELLING_AXE, 2));
		PlayerTools.AddTool(new Tool(ToolName.CROSSCUT_SAW));
		PlayerTools.AddTool(new Tool(ToolName.SPLITTING_AXE));

		if (PlayerContracts.GetActiveContractsList().Count == 0)
		{
			PlayerContracts.AddContract(new LumberContract(
				new LumberResourceQuantity(1, QualityGrade.F, 0, QualityGrade.F, 0, QualityGrade.F), 
				new DevResourceQuantity(100, 0, 0, 0), 
				3));
			PlayerContracts.AddContract(new LumberContract(
				new LumberResourceQuantity(0, QualityGrade.F, 4, QualityGrade.F, 0, QualityGrade.F), 
				new DevResourceQuantity(100, 0, 0, 0), 
				3));
			PlayerContracts.AddContract(new LumberContract(
				new LumberResourceQuantity(0, QualityGrade.F, 0, QualityGrade.F, 8, QualityGrade.F), 
				new DevResourceQuantity(100, 0, 0, 0), 
				3));
		}

	}
	
	void Update () 
	{	
		
	}

	public static void SetSpawnLocation(int start, int destination)
	{
		Debug.Log("Player Start Pos: " + playerTransform.position);
		Debug.Log("Spawn Location Pos: " + SpawnLocations.ReturnSpawnVector(start, destination));
		playerTransform.position = SpawnLocations.ReturnSpawnVector(start, destination);

		Debug.Log("Player End Pos: " + playerTransform.position);
	}
}
