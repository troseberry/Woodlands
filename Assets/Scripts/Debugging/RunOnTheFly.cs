using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class RunOnTheFly : MonoBehaviour 
{	
	public static RunOnTheFly RunOnTheFlyReference;
    private static bool rotfCreated;

    public int saveDataSlot;
	public bool simulateFromMenu;

    void Awake()
	{
		if (!rotfCreated)
		{
			DontDestroyOnLoad(gameObject);
			rotfCreated = true;
		}
		else
		{
			Destroy(gameObject);
		}	
	}

    void Start()
    {
		RunOnTheFlyReference = this;

        if (saveDataSlot > 0) LoadFromSaveSlot();
		// if (simulateFromMenu) SimulateLoadFromMenu();
    }

    public void LoadFromSaveSlot()
    {
        if (saveDataSlot > 0 && SaveLoad.DoesSaveExist(saveDataSlot))
        {
            SaveLoad.SetCurrentSaveSlot(saveDataSlot);
            SaveLoad.Load();
        }
        else
        {
            Debug.Log("No Save Exists in that Slot");
        }
    }

    public void CreateNewSave()
    {
        if (!SaveLoad.DoesSaveExist(1)) 
		{
			SaveLoad.SetCurrentSaveSlot(1);
		}
		else if (!SaveLoad.DoesSaveExist(2)) 
		{
			SaveLoad.SetCurrentSaveSlot(2);
		}
		else if (!SaveLoad.DoesSaveExist(3)) 
		{
			SaveLoad.SetCurrentSaveSlot(3);
		}
		
		SaveLoad.CreateNewSave();
		SaveLoad.Load();
    }

	// void SimulateLoadFromMenu()
	// {
	// 	AvailableContracts.GenerateNewContracts();
	// }

	public void PrintSaveLocation()
	{
		Debug.Log(Application.persistentDataPath);
	}
}
