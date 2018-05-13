using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverTool : EventTrigger
{
    private Color[] selectedColors = { new Color(1f, 1f, 1f), new Color(0f, 0f, 0f, 0.6f) };
    private Color[] deselectedColors = { new Color(1f, 1f, 1f, 0.4f), new Color(0f, 0f, 0f, 0.2f) };

    private RawImage toolImage;
    private RawImage iconBackground;

    void Start()
    {
        toolImage = transform.GetChild(0).GetComponent<RawImage>();
        iconBackground = GetComponent<RawImage>();
    }

	public override void OnPointerEnter(PointerEventData data)
    {
        int toolIndex = int.Parse(name.Substring(5, 2)) - 1;
        PlayerHud.PlayerHudReference.ToolWheelSwitchSetup(toolIndex);

        toolImage.color = selectedColors[0];
        iconBackground.color = selectedColors[1];
        Debug.Log("To Equip Index: " + toolIndex);
    }

    public void DeselectTool()
    {
        toolImage.color = deselectedColors[0];
        iconBackground.color = deselectedColors[1];
    }
}
