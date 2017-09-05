using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Forest
{
	public class SnapSpot : MonoBehaviour 
	{
		private ForestTreeBehavior parentTree;

		void Start()
		{
			parentTree = transform.parent.GetComponent<ForestTreeBehavior>();
		}

		void OnTriggerEnter()
		{	
			int side = 0;
			switch(name)
			{
				case "xSnap_01":
					side = 0;
					break;
				case "xSnap_02":
					side = 1;
					break;
				case "zSnap_01":
					side = 2;
					break;
				case "zSnap_02":
					side = 3;
					break;
			}
			
			ForestPlayerBehavior.PlayerBehaviorReference.SetSnapInfo(parentTree, transform, true, side);
		}

		void OnTriggerExit()
		{
			ForestPlayerBehavior.PlayerBehaviorReference.SetSnapInfo(false);
		}
	}
}