using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTool : EventTrigger
{

	public override void OnPointerEnter(PointerEventData data)
    {
        int toolIndex = int.Parse(name.Substring(5, 2)) - 1;
		PlayerHud.PlayerHudReference.CallForToolSwitch(toolIndex);
    }
}
