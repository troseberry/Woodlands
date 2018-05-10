using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerManager : MonoBehaviour 
{
	private static bool playerCreated;
	private static Transform playerTransform;
	private static Vector3 spawnLocation;

	private static bool didLoadFromMenu = false;

	public Transform playerLookAt;
	public Transform playerFollow;

	public CinemachineStateDrivenCamera stateDrivenCamera;
	// public CinemachineClearShot clearShotCamera_MainCabin;

	public static SceneSaveHandler currentSceneSaveHandler;
	
	// void Awake()
	// {
	// 	if (!playerCreated)
	// 	{
	// 		DontDestroyOnLoad(gameObject);
	// 		playerCreated = true;
	// 	}
	// 	else
	// 	{
	// 		Destroy(gameObject);
	// 	}	
	// }

	void Update()
	{
		DebugPanel.Log("Clear Shot? ", GameObject.Find("CM_ClearShotCamera_MainCabin") == null);
		
	}

	void Reset()
	{
		playerLookAt = GameObject.Find("Head").transform;
		playerFollow = GameObject.Find("Logger").transform;

		stateDrivenCamera = GameObject.Find("CM_StateDrivenCamera").GetComponent<CinemachineStateDrivenCamera>();
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		GameObject ssh = GameObject.Find("SceneSaveHandler");
		if (ssh) currentSceneSaveHandler = ssh.GetComponent<SceneSaveHandler>();
		
		//only do this on load from main menu
		if (!didLoadFromMenu /*&& RunOnTheFly.RunOnTheFlyReference.simulateFromMenu*/)
		{
			// spawnLocation = MainMenu.GetLocationToSpawn();
			// StartCoroutine(DelaySetSpawnLocationOnLoad());
			
			didLoadFromMenu = true;
		}

		if (scene.name.Equals("MainMenu")) didLoadFromMenu = false; //need to also destroy player object

		if (scene.name.Equals("MainCabin") || scene.name.Equals("Workshop"))
		{
			stateDrivenCamera.enabled = false;
			CharacterInputController.SetCanRun(false);

			if (scene.name.Equals("MainCabin")) GameObject.Find("CM_ClearShotCamera_MainCabin").GetComponent<CinemachineClearShot>().m_LookAt = playerLookAt;
			if (scene.name.Equals("Workshop")) GameObject.Find("CM_VirtualCamera_Workshop").GetComponent<CinemachineVirtualCamera>().m_LookAt = playerLookAt;
		}
		else
		{
			stateDrivenCamera.enabled = true;
			CharacterInputController.SetCanRun(true);
		}

		if (scene.name.Equals("MainCabin")) 
		{
			transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
		}
		else
		{
			transform.localScale = Vector3.one;
		}
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void Start () 
	{
		playerTransform = this.transform;

		playerLookAt = GameObject.Find("Head").transform;
		// playerFollow = GameObject.Find("Logger").transform;

		if (SceneManager.GetActiveScene().name.Equals("MainCabin")) 
		{
			transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
		}
		else
		{
			transform.localScale = Vector3.one;
		}
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

	public static void TraverseStairs(bool goUp)
	{
		playerTransform.position = goUp ? new Vector3(-3f, 3.8f, 0f) : new Vector3(1f, -0.5f, 0f);
	}

	public IEnumerator DelaySetSpawnLocationOnLoad()
	{
		yield return new WaitForSeconds(0.25f);

		playerTransform.position = spawnLocation;
	}

	public static void SetTransformData(Vector3 position, Quaternion rotation)
	{
		playerTransform.position = position;
		playerTransform.rotation = rotation;
	}
}
