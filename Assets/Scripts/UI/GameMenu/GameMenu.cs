using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour 
{
	private Canvas gameMenuCanvas;
	private bool gameMenuOpen = false;

	public SkillMenu skillMenu;
	public RoomsMenu roomsMenu;
	public ToolsMenu toolsMenu;
	public ContractsMenu contractsMenu;
	public ResourcesMenu resourcesMenu;

	void Start () 
	{
		gameMenuCanvas = GetComponent<Canvas>();
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Menu Button"))
		{
			ToggleGameMenu();
		}
	}

	void ToggleGameMenu()
	{
		gameMenuCanvas.enabled = !gameMenuCanvas.enabled;
		gameMenuOpen = !gameMenuOpen;

		if (gameMenuOpen)
		{
			skillMenu.OpenMenu();
		}
		else
		{
			CloseMenuTabs();
		}
	}
	


	public void SelectSkillsTab()
	{
		CloseMenuTabs();
		skillMenu.OpenMenu();
	}

	public void SelectToolsTab()
	{
		CloseMenuTabs();
		toolsMenu.OpenMenu();
	}

	public void SelectRoomsTab()
	{
		CloseMenuTabs();
		roomsMenu.OpenMenu();
	}

	public void SelectContractsTab()
	{
		CloseMenuTabs();
		contractsMenu.OpenMenu();
	}

	public void SelectResourcesTab()
	{
		CloseMenuTabs();
		resourcesMenu.OpenMenu();
	}


	void CloseMenuTabs()
	{
		skillMenu.CloseMenu();
		roomsMenu.CloseMenu();
		toolsMenu.CloseMenu();
		contractsMenu.CloseMenu();
		resourcesMenu.CloseMenu();
	}
}
