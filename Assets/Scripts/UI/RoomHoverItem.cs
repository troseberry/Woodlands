using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomHoverItem : MonoBehaviour 
{
	private HomesteadRoom associatedRoom;

	private Text roomName;
	private Text tierNumber;
	private Text roomDescription;
	private Text tierValue;

	public Transform toolTipGroup;

	void Start () 
	{
		switch(name)
		{
			case "Kitchen":
				associatedRoom = PlayerRooms.GetKitchenRoom();
				break;
			case "Bedroom":
				associatedRoom = PlayerRooms.GetBedRoom();
				break;
			case "Office":
				associatedRoom = PlayerRooms.GetOfficeRoom();
				break;
			case "Study":
				associatedRoom = PlayerRooms.GetStudyRoom();
				break;
			case "Workshop":
				associatedRoom = PlayerRooms.GetWorkshopRoom();
				break;
		}

		roomName = toolTipGroup.GetChild(0).GetComponent<Text>();
		tierNumber = toolTipGroup.GetChild(1).GetComponent<Text>();
		roomDescription = toolTipGroup.GetChild(2).GetComponent<Text>();
		tierValue = toolTipGroup.GetChild(3).GetComponent<Text>();
	}

	public void DisplayToolTip()
	{
		roomName.text = associatedRoom.GetRoomName().ToString();
		tierNumber.text = "Tier " + associatedRoom.GetCurrentTier().ToString();
		roomDescription.text = associatedRoom.GetRoomDescription();
		tierValue.text = associatedRoom.GetTierDescriptiveString();

		toolTipGroup.gameObject.SetActive(true);
	}

	public void HideToolTip()
	{
		toolTipGroup.gameObject.SetActive(false);
	}
}