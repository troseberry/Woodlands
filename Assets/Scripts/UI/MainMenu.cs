using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//only show load game button if a save exists
//only show start new game button if less than 3 saves exist


public class MainMenu : MonoBehaviour 
{
	public Transform[] mainButtons;
	public Transform saveSlotsGroup;

	void Start()
	{
		// Debug.Log("Save Data Here: " + Application.persistentDataPath);
		ShowMainButtons();
	}

	public void StartNewGame()
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
		SceneManager.LoadScene("MainCabin");
	}

	public void LoadGame()
	{
		HideMainButtons();
		mainButtons[0].gameObject.SetActive(true);
		ShowSaveSlots();
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	void HideMainButtons()
	{
		for (int i = 0; i < mainButtons.Length; i++)
		{
			mainButtons[i].gameObject.SetActive(false);
		}
	}

	void ShowMainButtons()
	{
		mainButtons[0].gameObject.SetActive(SaveLoad.DoesSaveExist(1));
		mainButtons[1].gameObject.SetActive(!SaveLoad.DoesSaveExist(3));
		mainButtons[2].gameObject.SetActive(true);
		mainButtons[3].gameObject.SetActive(true);
	}

	void ShowSaveSlots()
	{
		saveSlotsGroup.gameObject.SetActive(true);

		if (!SaveLoad.DoesSaveExist(2)) 
		{
			saveSlotsGroup.GetChild(1).GetComponent<Button>().enabled = false;
			saveSlotsGroup.GetChild(1).GetComponentInChildren<Text>().text = "Empty";
		}
		else
		{
			saveSlotsGroup.GetChild(1).GetComponent<Button>().enabled = true;
			saveSlotsGroup.GetChild(1).GetComponentInChildren<Text>().text = "Save Two";
		}

		if (!SaveLoad.DoesSaveExist(3)) 
		{
			saveSlotsGroup.GetChild(2).GetComponent<Button>().enabled = false;
			saveSlotsGroup.GetChild(2).GetComponentInChildren<Text>().text = "Empty";
		}
		else
		{
			saveSlotsGroup.GetChild(2).GetComponent<Button>().enabled = true;
			saveSlotsGroup.GetChild(2).GetComponentInChildren<Text>().text = "Save Three";
		}
	}

	void HideSaveSlots()
	{
		saveSlotsGroup.gameObject.SetActive(false);
	}

	public void LoadSelectSave()
	{
		string slotName = EventSystem.current.currentSelectedGameObject.name;
		switch (slotName)
		{
			case "Slot_01":
				SaveLoad.SetCurrentSaveSlot(1);
				break;
			case "Slot_02":
				SaveLoad.SetCurrentSaveSlot(2);
				break;
			case "Slot_03":
				SaveLoad.SetCurrentSaveSlot(3);
				break;
		}

		SaveLoad.Load();
		SceneManager.LoadScene("MainCabin");
	}

	public void BackFromSaveSlots()
	{
		HideSaveSlots();
		ShowMainButtons();
	}
}