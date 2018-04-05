using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneSaveHandler : MonoBehaviour
{
	public ObjectIdentity[] existingSceneObjects;


	void Start()
	{
		if (SaveLoadScene.SceneSaveExists("Forest")) LoadSceneData();
	}


	public void SaveSceneData()
	{
		SaveableSceneData newSceneData = new SaveableSceneData();
		List<SceneObject> sceneObjectsToSave = new List<SceneObject>();

		if (SaveLoadScene.SceneSaveExists("Forest"))
		{
			sceneObjectsToSave = SaveLoadScene.loadedScene.sceneObjects;
		}

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

				SceneObject matchingObj = sceneObjectsToSave.Where(obj => obj.id == newSceneObject.id).SingleOrDefault();

				if(matchingObj == null)
				{
					sceneObjectsToSave.Add(newSceneObject);
				}
				else
				{
					sceneObjectsToSave.Remove(matchingObj);
					sceneObjectsToSave.Add(newSceneObject);
				}
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
		SaveLoadScene.Load("Forest");
		SaveableSceneData loadedScene = SaveLoadScene.loadedScene;
		Debug.Log("Load Scene Objects: " + loadedScene.sceneObjects.Count);

		Debug.Log("Existing Scene Objects: " + existingSceneObjects.Length);

		for (int i = 0; i< loadedScene.sceneObjects.Count; i++)
		{
			for (int j = 0; j < existingSceneObjects.Length; j++)
			{
				if (loadedScene.sceneObjects[i].id == existingSceneObjects[j].id)
				{
					Debug.Log("Id Loaded: " + loadedScene.sceneObjects[i].id);
					Debug.Log("Id Loaded (Don't Load?): " + loadedScene.sceneObjects[i].dontLoad);

					if(!loadedScene.sceneObjects[i].dontLoad)
					{
						existingSceneObjects[j].dontLoad = loadedScene.sceneObjects[i].dontLoad;

						existingSceneObjects[j].transform.position = new Vector3(loadedScene.sceneObjects[i].posX, loadedScene.sceneObjects[i].posY, loadedScene.sceneObjects[i].posZ);

						existingSceneObjects[j].transform.rotation = new Quaternion(loadedScene.sceneObjects[i].rotX, loadedScene.sceneObjects[i].rotY, loadedScene.sceneObjects[i].rotZ, loadedScene.sceneObjects[i].rotW);

						existingSceneObjects[j].gameObject.SetActive(true);

						Debug.Log("Activating: " + existingSceneObjects[j].name + "(" + existingSceneObjects[j].id + ")");
					}
					else
					{
						existingSceneObjects[j].gameObject.SetActive(false);
					}
				}
			}
		}
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
