﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour 
{
	public static MenuManager currentMenuManager;
	
	public PauseMenu currentPauseMenu;
	public GameMenu currentGameMenu;

	public KeyItemInteract bedCanvas;
	public KeyItemInteract kitchenCanvas;
	public KeyItemInteract officeCanvas;
	public KeyItemInteract studyCanvas;
	public KeyItemInteract workshopCanvas;

	void Start () 
	{
		currentMenuManager = this;
	}
	
	public void CloseAllCanvases()
	{
		currentPauseMenu.CloseMenu();
		currentGameMenu.ImmediatelyCloseMenu();

		if (bedCanvas) bedCanvas.CloseMenu();
		if (kitchenCanvas) kitchenCanvas.CloseMenu();
		if (officeCanvas) officeCanvas.CloseMenu();
		if (studyCanvas) studyCanvas.CloseMenu();
		if (workshopCanvas) workshopCanvas.CloseMenu();
	}

	public void CloseKeyItemCanvases()
	{
		if (bedCanvas) bedCanvas.CloseMenu();
		if (kitchenCanvas) kitchenCanvas.CloseMenu();
		if (officeCanvas) officeCanvas.CloseMenu();
		if (studyCanvas) studyCanvas.CloseMenu();
		if (workshopCanvas) workshopCanvas.CloseMenu();
	}
}