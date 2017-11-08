using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHud : MonoBehaviour 
{
	public static PlayerHud PlayerHudReference;

	private Canvas playerCanvas;

	private float currentEnergyValue = 0f;
	private float maxEnergyValue;
	public Image energyRadial;
	public Text energyText;

	public Transform toolIconGroup;

	
	void Start () 
	{
		PlayerHudReference = this;

		playerCanvas = GetComponent<Canvas>();
		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();
		ChangeToolIcon();
	}
	
	void Update () 
	{
		currentEnergyValue = (float) PlayerEnergy.GetCurrentEnergyValue()/maxEnergyValue;
		energyRadial.fillAmount = currentEnergyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, currentEnergyValue);
		energyText.text = (currentEnergyValue * maxEnergyValue).ToString();
	}

	public void ChangeToolIcon()
	{
		for (int i = 0; i < toolIconGroup.childCount; i++)
		{
			toolIconGroup.GetChild(i).gameObject.SetActive(false);
		}
		toolIconGroup.GetChild(ToolManager.GetToolToEquipIndex()).gameObject.SetActive(true);
	}
}
