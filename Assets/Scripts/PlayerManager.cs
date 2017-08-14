using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
	//don't actually need refs to these here if everything inside them is static
	// public static PlayerInventory PlayerInventoryRef;
	// public static PlayerTools PlayerToolsRef;
	// public static PlayerSkills PlayerSkillsRef;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		DebugPanel.Log("Energy: ", PlayerInventory.GetEnergyValue());
		DebugPanel.Log("Currency: ", PlayerInventory.GetCurrencyValue());
		DebugPanel.Log("Lumber: ", PlayerInventory.GetLumberValue());
		DebugPanel.Log("Hardware: ", PlayerInventory.GetHardwareValue());
	}
}
