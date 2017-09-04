using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomName {BEDROOM, KITCHEN, OFFICE, STUDY, WORKSHOP}

public class HomesteadRoom
{
	protected RoomName roomName;
	protected int currentTier;
	protected int[] tierValues;
	protected DevResourceQuantity[] upgradeCosts;
	protected bool canBeUpgraded;
	
	public HomesteadRoom() {}

	public HomesteadRoom(RoomName name, int[] values, DevResourceQuantity[] costs)
	{
		roomName = name;
		currentTier = 1;
		tierValues = values;
		upgradeCosts = costs;
	}

	public HomesteadRoom(RoomName name, int tier, int[] values, DevResourceQuantity[] costs)
	{
		roomName = name;
		currentTier = tier;
		tierValues = values;
		upgradeCosts = costs;
	}

	public RoomName GetBuildingName() { return roomName; }

	public void SetBuildingName(RoomName name) { roomName = name; }

	public int GetCurrentTier() { return currentTier; }

	public void SetCurrentTier(int tier)
	{
		currentTier = tier;
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public int[] GetTierValues() { return tierValues; }

	public void SetTierValues(int[] values) { tierValues = values; }

	public int GetTierValueAtIndex(int index) { return tierValues[index]; }

	public void SetTierValueAtIndex(int index, int newValue) { tierValues[index] = newValue; }

	public DevResourceQuantity[] GetDevResourceQuantities() { return upgradeCosts; }

	public void SetDevResourceQuantities(DevResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public DevResourceQuantity GetDevResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetDevResourceQuantityAtTier(int tier, DevResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; }

	public bool CanBeUpgraded() { return canBeUpgraded; }
}

public class BedRoom : HomesteadRoom
{
	public BedRoom()
	{
		roomName = RoomName.BEDROOM;
		currentTier = 1;
		//for bunk room, b/c this is sleep duration, this should really be float vals for tiervalues(8, 7.5, 7, 6.5, 6). for now, this is just hours
		tierValues = new int[5]{9, 8, 7, 6, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public BedRoom(int tier)
	{
		roomName = RoomName.BEDROOM;
		currentTier = tier;
		tierValues = new int[5]{9, 8, 7, 6, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
}

public class KitchenRoom : HomesteadRoom
{
	public KitchenRoom()
	{
		roomName = RoomName.KITCHEN;
		currentTier = 1;
		tierValues = new int[5]{3, 5, 8, 10, 15};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public KitchenRoom(int tier)
	{
		roomName = RoomName.KITCHEN;
		currentTier = tier;
		tierValues = new int[5]{3, 5, 8, 10, 15};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
}

public class OfficeRoom : HomesteadRoom
{
	public OfficeRoom()
	{
		roomName = RoomName.OFFICE;
		currentTier = 1;
		//For Office, tiervalues should be an array of Tools eventually
		tierValues = new int[5]{0, 0, 0, 0, 0};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public OfficeRoom(int tier)
	{
		roomName = RoomName.OFFICE;
		currentTier = tier;
		tierValues = new int[5]{0, 0, 0, 0, 0};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
}

public class StudyRoom : HomesteadRoom
{
	public StudyRoom()
	{
		roomName = RoomName.STUDY;
		currentTier = 1;
		tierValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public StudyRoom(int tier)
	{
		roomName = RoomName.STUDY;
		currentTier = tier;
		tierValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
}

public class WorkshopRoom : HomesteadRoom
{
	public WorkshopRoom()
	{
		roomName = RoomName.WORKSHOP;
		currentTier = 1;
		tierValues = new int[5]{0, 1, 2, 3, 4};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public WorkshopRoom(int tier)
	{
		roomName = RoomName.WORKSHOP;
		currentTier = tier;
		tierValues = new int[5]{0, 1, 2, 3, 4};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
}

