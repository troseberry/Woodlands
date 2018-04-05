// Every time a gameobject with an Identifier script is created, the SetID needs to be called. 
// It's useful to create an Editor Extension to call the function during Edit mode if the scene is edited in Edit mode as opposed to runtime.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentity : MonoBehaviour
{
	public int id = -1;
	public bool dontLoad = false;

	void Reset()
	{
		SetID();
	}

	public void SetID()
	{
		id = 0;

		List<int> takenIDs = new List<int>();
		ObjectIdentity[] objects = GameObject.FindObjectsOfType(typeof (ObjectIdentity)) as ObjectIdentity[];

		// foreach (ObjectIdentity obj in objects)
		for (int i = 0; i < objects.Length; i++)
		{
			if (objects[i].transform.gameObject != gameObject)
			{
				takenIDs.Add(objects[i].id);
				Debug.Log("taken ID added: " + objects[i].id);
			}
		}

		if (takenIDs.Count > 0)
		{
			for (id = 0; id < takenIDs.Count; id++)
			{
				if (!takenIDs.Contains(id)) break;
			}
		}
		Debug.Log("New Object ID: " + id);
	}
}
