using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadScene
{
	private static string folderPath = "/SceneSaves";
	public static SaveableSceneData loadedScene = new SaveableSceneData();
	public static List<SaveableSceneData> savedScenes = new List<SaveableSceneData>();

	public static void Save(SaveableSceneData sceneData)
	{
		BinaryFormatter bf = new BinaryFormatter();
		

		if (!Directory.Exists(SaveLoad.GetCurrentSaveDirectory() + folderPath)) Directory.CreateDirectory(SaveLoad.GetCurrentSaveDirectory() + folderPath);

		string path = SaveLoad.GetCurrentSaveDirectory() + folderPath + "/" + sceneData.sceneName + ".sd";

		FileStream file = File.Create(path);

		bf.Serialize(file, sceneData);
		file.Close();
		// Debug.Log("Saved Scene: " + sceneData.sceneName);
	}

	public static void Load(string sceneToLoad)
	{
		string path = SaveLoad.GetCurrentSaveDirectory() + folderPath + "/" + sceneToLoad + ".sd";

		if (File.Exists(path))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(path, FileMode.Open);
			loadedScene = (SaveableSceneData)bf.Deserialize(file);
			file.Close();
			// Debug.Log("Loaded Scene: " + loadedScene.sceneName);
		}
	}

	public static bool SceneSaveExists(string sceneToLoad)
	{
		return File.Exists(SaveLoad.GetCurrentSaveDirectory() + folderPath + "/" + sceneToLoad + ".sd");
	}
}
