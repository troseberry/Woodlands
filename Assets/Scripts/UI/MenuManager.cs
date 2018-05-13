using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public static MenuManager currentMenuManager;

	public PauseMenu currentPauseMenu;
	public GameMenu currentGameMenu;
	public MailboxMenu currentMailboxMenu;

	public KeyItemInteract bedCanvas;
	public KeyItemInteract kitchenCanvas;
	public KeyItemInteract officeCanvas;
	public KeyItemInteract studyCanvas;
	public KeyItemInteract workshopCanvas;
	public KeyItemInteract mailboxCanvas;

	private bool inMenu;

	void Start () 
	{
		currentMenuManager = this;
	}

	void Update()
	{
		if (LoadingScreen.IsLoading()) CloseAllCanvases();
	}

	void Reset()
	{
		currentPauseMenu = GameObject.Find("PauseMenu").GetComponent<PauseMenu>();
		currentGameMenu = GameObject.Find("GameMenu").GetComponent<GameMenu>();

		if (SceneManager.GetActiveScene().name.Equals("Homestead"))
		{
			currentMailboxMenu = GameObject.Find("MailboxMenu").GetComponent<MailboxMenu>();
			mailboxCanvas = GameObject.Find("Mailbox").GetComponent<KeyItemInteract>();
		}

		if (SceneManager.GetActiveScene().name.Equals("MainCabin"))
		{
			bedCanvas = GameObject.Find("Bed").GetComponent<KeyItemInteract>();
			kitchenCanvas = GameObject.Find("KitchenTable").GetComponent<KeyItemInteract>();
			officeCanvas = GameObject.Find("Shop").GetComponent<KeyItemInteract>();
			studyCanvas = GameObject.Find("StudyMenuTrigger").GetComponent<KeyItemInteract>();
		}

		if (SceneManager.GetActiveScene().name.Equals("Workshop")) workshopCanvas = GameObject.Find("UpgradeTools").GetComponent<KeyItemInteract>();
	}
	
	public void CloseAllCanvases()
	{
		currentPauseMenu.CloseMenu();
		currentGameMenu.ImmediatelyCloseMenu();
		if (currentMailboxMenu) currentMailboxMenu.CloseMenu();

		// PlayerHud.PlayerHudReference.HideToolWheel(executeToolSwitch);

		if (bedCanvas) bedCanvas.CloseMenu();
		if (kitchenCanvas) kitchenCanvas.CloseMenu();
		if (officeCanvas) officeCanvas.CloseMenu();
		if (studyCanvas) studyCanvas.CloseMenu();
		if (workshopCanvas) workshopCanvas.CloseMenu();
		if (mailboxCanvas) mailboxCanvas.CloseMenu();
	}

	public void CloseKeyItemCanvases()
	{
		if (bedCanvas) bedCanvas.CloseMenu();
		if (kitchenCanvas) kitchenCanvas.CloseMenu();
		if (officeCanvas) officeCanvas.CloseMenu();
		if (studyCanvas) studyCanvas.CloseMenu();
		if (workshopCanvas) workshopCanvas.CloseMenu();
		if (mailboxCanvas) mailboxCanvas.CloseMenu();
	}

	public bool IsInMenu()
	{
		if (kitchenCanvas)
		{
			return currentGameMenu.IsMenuOpen() || bedCanvas.IsMenuOpen() || kitchenCanvas.IsMenuOpen() || officeCanvas.IsMenuOpen()
			|| studyCanvas.IsMenuOpen();
		}
		else if (workshopCanvas)
		{
			return currentGameMenu.IsMenuOpen() || workshopCanvas.IsMenuOpen();
		}
		else if (mailboxCanvas)
		{
			return currentGameMenu.IsMenuOpen() || mailboxCanvas.IsMenuOpen();
		}
		else
		{
			currentGameMenu.IsMenuOpen(); 
		}
		return false;
	}

	public void UpdateMenusAtStartOfDay()
	{
		currentGameMenu.UpdateAtStartOfDay();
		if (currentMailboxMenu) currentMailboxMenu.ShowContracts();
	}
}