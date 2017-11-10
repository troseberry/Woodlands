using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRoomUpgrades : MonoBehaviour 
{

	public void UpgradeBedroom()
	{
		BedRoom bedroom = PlayerRooms.GetBedRoom();
		if (bedroom.CanBeUpgraded())
		{
			int currentTier = PlayerRooms.GetBedRoomTier();

			if (bedroom.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerRooms.SetBedRoomTier(currentTier + 1);
				bedroom.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				ShopCanvas.TriggerRoomsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources:" + bedroom.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: BEDROOM ");
		}
	}

	public void UpgradeKitchen()
	{
		KitchenRoom kitchen = PlayerRooms.GetKitchenRoom();
		if (kitchen.CanBeUpgraded())
		{
			int currentTier = PlayerRooms.GetKitchenRoomTier();

			if (kitchen.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerRooms.SetKitchenRoomTier(currentTier + 1);
				kitchen.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				ShopCanvas.TriggerRoomsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources:" + kitchen.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: KITCHEN ");
		}
	}

	public void UpgradeOffice()
	{
		OfficeRoom office = PlayerRooms.GetOfficeRoom();
		if (office.CanBeUpgraded())
		{
			int currentTier = PlayerRooms.GetOfficeRoomTier();

			if (office.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerRooms.SetOfficeRoomTier(currentTier + 1);
				office.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				ShopCanvas.TriggerRoomsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources:" + office.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: OFFICE ");
		}
	}

	public void UpgradeStudy()
	{
		StudyRoom study = PlayerRooms.GetStudyRoom();
		if (study.CanBeUpgraded())
		{
			int currentTier = PlayerRooms.GetStudyRoomTier();

			if (study.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerRooms.SetStudyRoomTier(currentTier + 1);
				study.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				ShopCanvas.TriggerRoomsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources:" + study.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: STUDY ");
		}
	}

	public void UpgradeWorkshop()
	{
		WorkshopRoom workshop = PlayerRooms.GetWorkshopRoom();
		if (workshop.CanBeUpgraded())
		{
			int currentTier = PlayerRooms.GetWorkshopRoomTier();

			if (workshop.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerRooms.SetWorkshopRoomTier(currentTier + 1);
				workshop.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				ShopCanvas.TriggerRoomsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources:" + workshop.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: WORKSHOP ");
		}
	}
}
