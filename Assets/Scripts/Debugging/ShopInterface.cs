using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInterface : MonoBehaviour 
{

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}


	public void BuyFellingAxe()
	{
		PlayerTools.AddTool(new Tool(ToolName.FELLING_AXE));
	}

	public void SellFellingAxe()
	{
		PlayerTools.RemoveTool(ToolName.FELLING_AXE);
		//Give currency and maybe resources
	}

	public void BuyCrosscutSaw()
	{
		PlayerTools.AddTool(new Tool(ToolName.CROSSCUT_SAW));
	}

	public void SellCrosscutSaw()
	{
		PlayerTools.RemoveTool(ToolName.CROSSCUT_SAW);
		//Give currency and maybe resources
	}

	public void BuySplittingAxe()
	{
		PlayerTools.AddTool(new Tool(ToolName.SPLITTING_AXE));
	}
	
	public void SellSplittingAxe()
	{
		PlayerTools.RemoveTool(ToolName.SPLITTING_AXE);
		//Give currency and maybe resources
	}
}
