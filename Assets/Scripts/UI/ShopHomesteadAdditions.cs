using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHomesteadAdditions : MonoBehaviour
{

	public void PurchaseCoffeeMaker()
	{
		CoffeeMakerAddition addition = PlayerAdditions.GetCoffeeMakerAddition();

		if (!addition.GetIsUnlocked())
		{
			if (addition.GetPurchaseCosts().HasInInventory())
			{
				addition.GetPurchaseCosts().SubtractFromInventory();
				PlayerAdditions.GetCoffeeMakerAddition().SetIsUnlocked(true);
				ShopCanvas.TriggerAdditionsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources");
			}
		}
		else
		{
			Debug.Log("Already Purchased: COFFEE MAKER");
		}
	}

	public void PurchaseFireplace()
	{
		FireplaceAddition addition = PlayerAdditions.GetFireplaceAddition();

		if (!addition.GetIsUnlocked())
		{
			if (addition.GetPurchaseCosts().HasInInventory())
			{
				addition.GetPurchaseCosts().SubtractFromInventory();
				PlayerAdditions.GetFireplaceAddition().SetIsUnlocked(true);
				ShopCanvas.TriggerAdditionsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources");
			}
		}
		else
		{
			Debug.Log("Already Purchased: FIREPLACE");
		}
	}

	public void PurchaseFrontPorch()
	{
		FrontPorchAddition addition = PlayerAdditions.GetFrontPorchAddition();

		if (!addition.GetIsUnlocked())
		{
			if (addition.GetPurchaseCosts().HasInInventory())
			{
				addition.GetPurchaseCosts().SubtractFromInventory();
				PlayerAdditions.GetFrontPorchAddition().SetIsUnlocked(true);
				ShopCanvas.TriggerAdditionsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources");
			}
		}
		else
		{
			Debug.Log("Already Purchased: FRONT PORCH");
		}
	}

	public void PurchaseWoodworkingBench()
	{
		WoodworkingBenchAddition addition = PlayerAdditions.GetWoodworkingBenchAddition();

		if (!addition.GetIsUnlocked())
		{
			if (addition.GetPurchaseCosts().HasInInventory())
			{
				addition.GetPurchaseCosts().SubtractFromInventory();
				PlayerAdditions.GetWoodworkingBenchAddition().SetIsUnlocked(true);
				ShopCanvas.TriggerAdditionsInfoUpdate();
			}
			else
			{
				Debug.Log("Insufficient Resources");
			}
		}
		else
		{
			Debug.Log("Already Purchased: WOODWORKING BENCH");
		}
	}
}
