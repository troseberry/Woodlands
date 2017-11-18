using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//don't think this needs to inherit from monobehaviour?
public class SaveLoad : MonoBehaviour 
{

	public static void Save()
	{
		BinaryFormatter data = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/gameSave.dat");

		SaveableData saveData = new SaveableData();

		//-----------------------Saving Data---------------------------------------------
		Hashtable dataToSave = new Hashtable();

		dataToSave.Add("activeContracts", PlayerContracts.GetActiveContractsList());

		//-----------------------Done Saving---------------------------------------------
		data.Serialize(file, dataToSave);
		file.Close();
		Debug.Log("Saved here: " + Application.persistentDataPath);
	}

	public static void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/gameSave.dat"))
		{
			Debug.Log("Loading...");

			BinaryFormatter data = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameSave.dat", FileMode.Open);
			Hashtable saveData = (Hashtable) data.Deserialize(file);
			file.Close();

			//-----------------------Loading Stats---------------------------------
			PlayerContracts.SetActiveContractsList( (List<LumberContract>) saveData["activeContracts"]);

			//-----------------------Done Loading----------------------------------
		}
		else {
			Save();
		}
	}
}