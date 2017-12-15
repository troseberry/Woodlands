using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour 
{
	private static bool playerCreated;
	private static Transform playerTransform;
	private static Vector3 spawnLocation;

	private static bool didLoadFromMenu = false;
	
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
		if (!didLoadFromMenu /*&& RunOnTheFly.RunOnTheFlyReference.simulateFromMenu*/)
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


		// int difficulty = 53;

		// int grade = 0;
		// int typeCount = 0;
		// int rangeMax = 0;

		// grade = UnityEngine.Random.Range(1, 6);
		// difficulty -= grade;

		// rangeMax = UnityEngine.Random.Range(1, 17);
		// rangeMax = Mathf.Clamp(rangeMax, 1, difficulty);
		// difficulty = difficulty / rangeMax;

		// typeCount = UnityEngine.Random.Range(1, 4);
		// typeCount = Mathf.Clamp(typeCount, 1, difficulty);
		// difficulty -= typeCount;

		// Debug.Log("Grade: " + grade);
		// Debug.Log("RangeMax: " + rangeMax);
		// Debug.Log("TypeCount: " + typeCount);
		// Debug.Log("Difficulty: " + difficulty);
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
