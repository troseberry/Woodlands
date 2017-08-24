using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSpot : MonoBehaviour 
{
	public TreeBehavior parentTreeBehavior;

	void OnStart()
	{
		// parentTreeBehavior = transform.parent.GetComponent<TreeBehavior>();
	}

	void OnTriggerEnter()
	{
		parentTreeBehavior.SetSnapInfo(transform, true);
	}

	void OnTriggerExit()
	{
		parentTreeBehavior.SetSnapInfo(false);
	}
}
