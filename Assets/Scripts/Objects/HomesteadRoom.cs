using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum RoomName {BEDROOM, KITCHEN, OFFICE, STUDY, WORKSHOP}

[Serializable]
public class HomesteadRoom
{
	protected RoomName roomName;
	protected int currentTier;
	protected int[] tierIntValues;
	protected float[] tierFloatValues;
	protected DevResourceQuantity[] upgradeCosts;
	protected bool canBeUpgraded;
	protected string description;
	protected string tierDescriptiveString;
	
	public HomesteadRoom() {}

	public HomesteadRoom(RoomName name, int[] values, DevResourceQuantity[] costs)
	{
		roomName = name;
		currentTier = 1;
		tierIntValues = values;
		upgradeCosts = costs;
	}

	public HomesteadRoom(RoomName name, int tier, int[] values, DevResourceQuantity[] costs)
	{
		roomName = name;
		currentTier = tier;
		tierIntValues = values;
		upgradeCosts = costs;
	}

	public RoomName GetRoomName() { return roomName; }

	public void SetRoomName(RoomName name) { roomName = name; }

	public int GetCurrentTier() { return currentTier; }

	public void SetCurrentTier(int tier)
	{
		currentTier = tier;
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public int[] GetTierValues() { return tierIntValues; }

	public void SetTierValues(int[] values) { tierIntValues = values; }

	public int GetTierValueAtIndex(int index) { return tierIntValues[index]; }

	public void SetTierValueAtIndex(int index, int newValue) { tierIntValues[index] = newValue; }

	public float[] GetTierFloatValues() { return tierFloatValues; }

	public void SetTierFloatValues(float[] values) { tierFloatValues = values; }

	public float GetTierFloatValueAtIndex(int index) { return tierFloatValues[index]; }

	public void SetTierFloatValueAtIndex(int index, float newValue) { tierFloatValues[index] = newValue; }

	public string GetTierDescriptiveString() { return tierDescriptiveString; }

	public DevResourceQuantity[] GetDevResourceQuantities() { return upgradeCosts; }

	public void SetDevResourceQuantities(DevResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public DevResourceQuantity GetDevResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetDevResourceQuantityAtTier(int tier, DevResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; }

	public bool CanBeUpgraded() { return canBeUpgraded; }

	public string GetRoomDescription() { return description; }
}

[Serializable]
public class BedRoom : HomesteadRoom
{
	public BedRoom()
	{
		roomName = RoomName.BEDROOM;
		currentTier = 1;
		//for bunk room, b/c this is sleep duration, this should really be float vals for tiervalues(8, 7.5, 7, 6.5, 6). for now, this is just hours
		tierFloatValues = new float[5]{8f, 7.5f, 7f, 6f, 6.5f};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Sleep duration required to completely restore energy.";
		tierDescriptiveString = tierFloatValues[currentTier - 1] + " hours for a full rest.";
	}

	public BedRoom(int tier)
	{
		roomName = RoomName.BEDROOM;
		currentTier = tier;
		tierFloatValues = new float[5]{8f, 7.5f, 7f, 6f, 6.5f};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Sleep duration required to completely restore energy.";
		tierDescriptiveString = tierFloatValues[currentTier - 1] + " hours for a full rest.";
	}
}

[Serializable]
public class KitchenRoom : HomesteadRoom
{
	public KitchenRoom()
	{
		roomName = RoomName.KITCHEN;
		currentTier = 1;
		tierIntValues = new int[5]{3, 5, 8, 10, 15};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "The maximum number of Lumber Contracts that can be displayed in the newspaper.";
		tierDescriptiveString = tierIntValues[currentTier - 1] + " available contracts";
	}

	public KitchenRoom(int tier)
	{
		roomName = RoomName.KITCHEN;
		currentTier = tier;
		tierIntValues = new int[5]{3, 5, 8, 10, 15};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "The maximum number of Lumber Contracts that can be displayed in the newspaper.";
		tierDescriptiveString = tierIntValues[currentTier - 1] + " available contracts";
	}
}

[Serializable]
public class OfficeRoom : HomesteadRoom
{
	public OfficeRoom()
	{
		roomName = RoomName.OFFICE;
		currentTier = 1;
		//tiervalues represent the max level (quality grade equivalent) of the tools available to puchase
		tierIntValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Highest level of Tools available in the store.";
		tierDescriptiveString = "Level " + currentTier + " tools available for purchase";
	}

	public OfficeRoom(int tier)
	{
		roomName = RoomName.OFFICE;
		currentTier = tier;
		tierIntValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Highest level of Tools available in the store.";
		tierDescriptiveString = "Level " + currentTier + " tools available for purchase";
	}
}

[Serializable]
public class StudyRoom : HomesteadRoom
{
	public StudyRoom()
	{
		roomName = RoomName.STUDY;
		currentTier = 1;
		tierIntValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Highest level of Books available in the Study";
		tierDescriptiveString = "Level " + currentTier + " books available for reading";
	}

	public StudyRoom(int tier)
	{
		roomName = RoomName.STUDY;
		currentTier = tier;
		tierIntValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Highest level of Books available in the Study";
		tierDescriptiveString = "Level " + currentTier + " books available for reading";
	}
}

[Serializable]
public class WorkshopRoom : HomesteadRoom
{
	public WorkshopRoom()
	{
		roomName = RoomName.WORKSHOP;
		currentTier = 1;
		tierIntValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum level of Tool that can be upgraded in the Workshop";
		tierDescriptiveString = "Able to upgrade level " + currentTier + " tools";
	}

	public WorkshopRoom(int tier)
	{
		roomName = RoomName.WORKSHOP;
		currentTier = tier;
		tierIntValues = new int[5]{1, 2, 3, 4, 5};
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum level of Tool that can be upgraded in the Workshop";
		tierDescriptiveString = "Able to upgrade level " + currentTier + " tools";
	}
}

