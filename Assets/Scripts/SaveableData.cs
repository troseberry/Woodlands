﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveableData 
{
	public List<LumberContract> activeContracts;

	public int currentEnergy;

	public int currentCurrency;
	public int currentBuildingMaterials;
	public int currentToolParts;
	public int currentBookPages;

	public int[] homesteadTreesCount;
	public int[] homesteadLogsCount;
	public int[] homesteadFirewoodCount;

	public List<Tool> ownedTools;

	public EfficiencySkill efficiencySkill;
	public ActiveContractsSkill contractsSkill;
	public CurrencySkill currencySkill;
	public EnergySkill energySkill;
	public BuildingMaterialsSkill buildingMaterialsSkill;
	public ToolPartsSkill toolPartsSkill;
	public BookPagesSkill bookPagesSkill;
	public LumberTreesSkill lumberTreesSkill;
	public LumberLogsSkill lumberLogsSkill;
	public LumberFirewoodSkill lumberFirewoodSkill;

	public BedRoom bedRoom;
	public KitchenRoom kitchenRoom;
	public OfficeRoom officeRoom;
	public StudyRoom studyRoom;
	public WorkshopRoom workshopRoom;
}