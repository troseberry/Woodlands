using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum AdditionName {COFFEE_MAKER, FIREPLACE, FRONT_PORCH, WOODWORKING_BENCH}

[Serializable]
public class HomesteadAddition
{
	protected AdditionName additionName;
	protected bool isUnlocked;
	protected DevResourceQuantity purchaseCosts;
	protected string description;

	public HomesteadAddition() {}

	public HomesteadAddition(AdditionName name, bool unlocked, DevResourceQuantity costs)
	{
		additionName = name;
		isUnlocked = unlocked;
		purchaseCosts = costs;
	}

	public AdditionName GetAdditionName() { return additionName; }

	public void SetAdditionName(AdditionName name) { additionName = name; }

	public bool GetIsUnlocked() { return isUnlocked; }

	public void SetIsUnlocked(bool unlocked) { isUnlocked = unlocked; }

	public DevResourceQuantity GetPurchaseCosts() { return purchaseCosts; }

	public void SetPurchaseCosts(DevResourceQuantity costs) { purchaseCosts = costs; }

	public string GetDescription() { return description; }
}

[Serializable]
public class CoffeeMakerAddition : HomesteadAddition
{
	public CoffeeMakerAddition()
	{
		additionName = AdditionName.COFFEE_MAKER;
		isUnlocked = false;
		purchaseCosts = new DevResourceQuantity(250, 0, 0, 0);
		description = "An addition for the kitchen. Make a cup of coffee to replenish a bit of energy. [Requires currency. Max of 2 per day.]";
	}
}

[Serializable]
public class FireplaceAddition : HomesteadAddition
{
	public FireplaceAddition()
	{
		additionName = AdditionName.FIREPLACE;
		isUnlocked = false;
		purchaseCosts = new DevResourceQuantity(1000, 100, 0, 0);
		description = "A fireplace for the den. Keeps the cabin toasty in the winter months.";
	}
}

[Serializable]
public class FrontPorchAddition : HomesteadAddition
{
	public FrontPorchAddition()
	{
		additionName = AdditionName.FRONT_PORCH;
		isUnlocked = false;
		purchaseCosts = new DevResourceQuantity(500, 50, 0, 0);
		description = "Adds a porch to the front of the cabin. A nice place to sit and whittle or to just take it all in.";
	}
}

[Serializable]
public class WoodworkingBenchAddition : HomesteadAddition
{
	public WoodworkingBenchAddition()
	{
		additionName = AdditionName.WOODWORKING_BENCH;
		isUnlocked = false;
		purchaseCosts = new DevResourceQuantity(250, 25, 50, 0);
		description = "A woodworking bench for the workshop. Can be used to make furniture, instruments, and other knick knacks.";
	}
}
