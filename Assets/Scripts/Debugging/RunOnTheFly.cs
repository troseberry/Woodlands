using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunOnTheFly : MonoBehaviour 
{	
    public int saveDataSlot;

    void Start()
    {
        if (saveDataSlot > 0) LoadFromSaveSlot();
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
}
