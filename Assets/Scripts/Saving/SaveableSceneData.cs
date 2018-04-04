using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableSceneData
{
	public string sceneName;
	public List<SceneObject> sceneObjects = new List<SceneObject>();
}
