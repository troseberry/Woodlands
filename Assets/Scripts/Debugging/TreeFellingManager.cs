using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFellingManager : MonoBehaviour 
{

	public void AwardPayout()
	{
		ContractGameInfo.GetPayout().AddToInventory();
		SceneNavigation.ToHomestead();
	}
}
