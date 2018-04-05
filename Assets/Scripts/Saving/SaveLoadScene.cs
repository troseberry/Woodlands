using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadScene
{
	public static SaveableSceneData loadedScene = new SaveableSceneData();
	public static List<SaveableSceneData> savedScenes = new List<SaveableSceneData>();

	public static void Save(SaveableSceneData sceneData)
	{
		BinaryFormatter bf = new BinaryFormatter();

		string path = Application.persistentDataPath + "/";

		FileStream file = File.Create(path + sceneData.sceneName + ".sd");

		bf.Serialize(file, sceneData);
		file.Close();
		Debug.Log("Saved Scene: " + sceneData.sceneName);
	}

	public static void Load(string sceneToLoad)
	{
		string path = Application.persistentDataPath + "/";

		if (File.Exists(path + sceneToLoad + ".sd"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(path + sceneToLoad + ".sd", FileMode.Open);
			loadedScene = (SaveableSceneData)bf.Deserialize(file);
			file.Close();
			Debug.Log("Loaded Scene: " + loadedScene.sceneName);
		}
	}

	public static bool SceneSaveExists(string sceneToLoad)
	{
		return File.Exists(Application.persistentDataPath + "/" + sceneToLoad + ".sd");
	}
}
