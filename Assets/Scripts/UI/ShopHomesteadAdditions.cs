using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHomesteadAdditions : MonoBehaviour
{
	public HomesteadAdditionHandler[] cabinAdditionHandlers;

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

				// For this to immedialty show up, have to manually trigger
				// because the addition exists in the same scene as the menu
				cabinAdditionHandlers[0].HandleAdditions();
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
				cabinAdditionHandlers[1].HandleAdditions();
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
