using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomesteadAdditionHandler : MonoBehaviour
{
	public AdditionName addition;

	public GameObject[] toEnable;
	public GameObject[] toDisable;

	void Start ()
	{
		HandleAdditions();
	}

	public void HandleAdditions()
	{
		switch(addition.ToString())
		{
			case "COFFEE_MAKER":
				TriggerObjects(PlayerAdditions.GetCoffeeMakerAddition().GetIsUnlocked());
				break;
			case "FRONT_PORCH":
				TriggerObjects(PlayerAdditions.GetFrontPorchAddition().GetIsUnlocked());
				break;
			case "FIREPLACE":
				TriggerObjects(PlayerAdditions.GetFireplaceAddition().GetIsUnlocked());
				break;
			case "WOODWORKING_BENCH":
				TriggerObjects(PlayerAdditions.GetWoodworkingBenchAddition().GetIsUnlocked());
				break;
		}
	}

	void TriggerObjects(bool additionActive)
	{
		for (int i = 0; i < toEnable.Length; i++)
		{
			toEnable[i].SetActive(additionActive);
		}

		for (int j = 0; j < toDisable.Length; j++)
		{
			toDisable[j].SetActive(!additionActive);
		}
	}
}
