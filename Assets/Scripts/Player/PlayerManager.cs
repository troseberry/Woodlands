﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour 
{
	private static bool playerCreated;
	private static Transform playerTransform;
	private static Vector3 spawnLocation;

	private bool didLoadFromMenu = false;
	
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

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		//only do this on load from main menu
		if (!didLoadFromMenu)
		{
			spawnLocation = MainMenu.GetLocationToSpawn();
			StartCoroutine(DelaySetSpawnLocationOnLoad());
			
			didLoadFromMenu = true;
		}

		if (scene.name.Equals("MainMenu")) didLoadFromMenu = false;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Start () 
	{
		playerTransform = this.transform;

		PlayerTools.AddTool(new Tool(ToolName.EMPTY_HANDS));
		PlayerTools.AddTool(new Tool(ToolName.FELLING_AXE, 2));
		PlayerTools.AddTool(new Tool(ToolName.CROSSCUT_SAW));
		PlayerTools.AddTool(new Tool(ToolName.SPLITTING_AXE));

		// if (PlayerContracts.GetActiveContractsList().Count == 0)
		// {
		// 	PlayerContracts.AddContract(new LumberContract(
		// 		new LumberResourceQuantity(1, QualityGrade.F, 0, QualityGrade.F, 0, QualityGrade.F), 
		// 		new DevResourceQuantity(100, 0, 0, 0), 
		// 		3));
		// 	PlayerContracts.AddContract(new LumberContract(
		// 		new LumberResourceQuantity(0, QualityGrade.F, 4, QualityGrade.F, 0, QualityGrade.F), 
		// 		new DevResourceQuantity(100, 0, 0, 0), 
		// 		3));
		// 	PlayerContracts.AddContract(new LumberContract(
		// 		new LumberResourceQuantity(0, QualityGrade.F, 0, QualityGrade.F, 8, QualityGrade.F), 
		// 		new DevResourceQuantity(100, 0, 0, 0), 
		// 		3));
		// }
	}

	public static void SetSpawnLocation(int start, int destination)
	{
		playerTransform.position = SpawnLocations.ReturnSpawnVector(start, destination);
	}

	public static void SetSpawnLocation(string start, string end)
	{
		int startScene = SpawnLocations.ParseString(start).GetHashCode();
		int endScene = SpawnLocations.ParseString(end).GetHashCode();

		playerTransform.position = SpawnLocations.ReturnSpawnVector(startScene, endScene);
	}

	public IEnumerator DelaySetSpawnLocationOnLoad()
	{
		yield return new WaitForSeconds(0.25f);

		playerTransform.position = spawnLocation;
	}
}
