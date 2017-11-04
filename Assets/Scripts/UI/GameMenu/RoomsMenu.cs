using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomsMenu : MonoBehaviour 
{
	private bool menuActive = false;

	private Text bedRoomTier, kitchenTier, officeTier, studyTier, workshopTier;

	private Text bedRoomValue, kitchenValue, officeValue, studyValue, workshopValue;

	public GameObject bedRoomGroup, kitchenGroup, officeGroup, studyGroup, workshopGroup;


	void Start () 
	{
		bedRoomTier = bedRoomGroup.transform.GetChild(1).GetComponent<Text>();
		bedRoomValue = bedRoomGroup.transform.GetChild(2).GetComponent<Text>();

		kitchenTier = kitchenGroup.transform.GetChild(1).GetComponent<Text>();
		kitchenValue = kitchenGroup.transform.GetChild(2).GetComponent<Text>();

		officeTier = officeGroup.transform.GetChild(1).GetComponent<Text>();
		officeValue = officeGroup.transform.GetChild(2).GetComponent<Text>();

		studyTier = studyGroup.transform.GetChild(1).GetComponent<Text>();
		studyValue = studyGroup.transform.GetChild(2).GetComponent<Text>();

		workshopTier = workshopGroup.transform.GetChild(1).GetComponent<Text>();
		workshopValue = workshopGroup.transform.GetChild(2).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (menuActive)
		{
			//These should not all say Capacity
			bedRoomTier.text = "Tier: " + PlayerRooms.GetBedRoomTier();
			bedRoomValue.text = "Capacity: " + PlayerRooms.GetBedRoomValue();

			kitchenTier.text = "Tier: " + PlayerRooms.GetKitchenRoomTier();
			kitchenValue.text = "Capacity: " + PlayerRooms.GetKitchenRoomValue();
			
			officeTier.text = "Tier: " + PlayerRooms.GetOfficeRoomTier();
			officeValue.text = "Capacity: " + PlayerRooms.GetOfficeRoomValue();
			
			studyTier.text = "Tier: " + PlayerRooms.GetStudyRoomTier();
			studyValue.text = "Capacity: " + PlayerRooms.GetStudyRoomValue();
			
			workshopTier.text = "Tier: " + PlayerRooms.GetWorkshopRoomTier();
			workshopValue.text = "Capacity: " + PlayerRooms.GetWorkshopRoomValue();
		}
	}

	public void OpenMenu()
	{
		menuActive = true;
		gameObject.SetActive(true);
	}

	public void CloseMenu()
	{
		menuActive = false;
		gameObject.SetActive(false);
	}
}
