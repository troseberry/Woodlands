﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSaveHandler : MonoBehaviour
{
	public Dictionary<string, GameObject> prefabDictionary;

	void Start()
	{
		prefabDictionary = new Dictionary<string, GameObject>();

		GameObject[] objects = Resources.LoadAll<GameObject>("ForestPrefabs");

		for (int i = 0; i < objects.Length; i++)
		{
			if (!prefabDictionary.ContainsKey(objects[i].name))
			{
				prefabDictionary.Add(objects[i].name, objects[i]);
			}
		}

		LoadSceneData();
	}


	public void SaveSceneData()
	{
		SaveableSceneData newSceneData = new SaveableSceneData();
		List<SceneObject> sceneObjectsToSave = new List<SceneObject>();

		object[] allObjects = GameObject.FindObjectsOfType(typeof (GameObject));
		Debug.Log("All Scene GOs: " + allObjects.Length);
		for (int i = 0; i < allObjects.Length; i++)
		{
			GameObject currentObj = (GameObject) allObjects[i];

			ObjectIdentity idScript = currentObj.GetComponent<ObjectIdentity>();
			if (idScript != null)
			{
				Debug.Log("Found Object With ID: " + idScript.id);

				SceneObject newSceneObject = new SceneObject();
				newSceneObject.name = currentObj.name;
				newSceneObject.id = idScript.id;

				newSceneObject.dontLoad = idScript.dontLoad;

				newSceneObject.posX = currentObj.transform.position.x;
				newSceneObject.posY = currentObj.transform.position.y;
				newSceneObject.posZ = currentObj.transform.position.z;

				newSceneObject.rotX = currentObj.transform.rotation.x;
				newSceneObject.rotY = currentObj.transform.rotation.y;
				newSceneObject.rotZ = currentObj.transform.rotation.z;
				newSceneObject.rotW = currentObj.transform.rotation.w;

				sceneObjectsToSave.Add(newSceneObject);
			}
		}
		Debug.Log("Scene Objects to Save: " + sceneObjectsToSave.Count);

		newSceneData.sceneName = "Forest";
		newSceneData.sceneObjects = sceneObjectsToSave;

		SaveLoadScene.Save(newSceneData);
		Debug.Log("Finished Saving (Save Handler)");
	}



	public void LoadSceneData()
	{
		// For this to work correctly there needs to be a default load state already existing
		// before the player ever loads into the scene for the first time.
		ClearScene();

		SaveLoadScene.Load("Forest");
		SaveableSceneData loadedScene = SaveLoadScene.loadedScene;
		Debug.Log("Load Scene Objects: " + loadedScene.sceneObjects.Count);


		foreach (SceneObject loadedObj in loadedScene.sceneObjects)
		{
			if (!loadedObj.dontLoad)
			{
				// Prefabs need to be instantiated as children of the correct parent
				// Aso need to determine where the best place for the ObjectIndentity
				// script is on ForestTrees. Having them on the outermost parent means
				// visually stumps don't get left behind. Trees completely disapper
				GameObject currentObj = Instantiate(prefabDictionary[loadedObj.name],
				new Vector3(loadedObj.posX, loadedObj.posY, loadedObj.posZ),
				new Quaternion(loadedObj.rotX, loadedObj.rotY, loadedObj.rotZ, loadedObj.rotW)) as GameObject;

				currentObj.name = loadedObj.name;

				if (!currentObj.GetComponent<ObjectIdentity>())
				{
					ObjectIdentity objectId = currentObj.AddComponent<ObjectIdentity>();
				}

				ObjectIdentity idScript = currentObj.GetComponent<ObjectIdentity>();
				idScript.id = loadedObj.id;
				
				Debug.Log("GameObject Loaded: " + currentObj.name + "(" + idScript.id + ")");
			}
		}
	}

	void ClearScene()
	{
		// THis currently deletes all existing SceneObjects (i.e. all objects with an
		// ObjectIdentity behavior script) then instantiates them again if they should load
		// according to the .sd file for the scene in question
		// There probably is a more efficienct method, but this currently works
		object[] objects = GameObject.FindObjectsOfType(typeof (GameObject));
		Debug.Log("Clearing. Searching: " + objects.Length);
		for (int i = 0; i < objects.Length; i++)
		{
			GameObject currentGameObject = (GameObject) objects[i];

			ObjectIdentity idScript = currentGameObject.GetComponent<ObjectIdentity>();
			if (idScript != null)
			{
				Debug.Log("Found Scene Object: " + idScript.id);
			}

			if (idScript != null /*&& idScript.dontLoad*/)
			{
				Debug.Log("Destroying: " + currentGameObject.name);
				Destroy(currentGameObject);
			}
		}
	}

	void OnDestroy()
	{
		// Debug.Log("Scene On Destroy");
		// SaveSceneData();
	}

	void Update()
	{
		// Need to implement an actual load screen with wait time so this can happen
		// automatically before transitioning to the next scene instead 
		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log("Triggered Save");
			SaveSceneData();
		}
	}
}
