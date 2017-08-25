using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeFelling
{
	public class SnapSpot : MonoBehaviour 
	{
		private TreeBehavior parentTree;

		void Start()
		{
			parentTree = transform.parent.GetComponent<TreeBehavior>();
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
			
			PlayerBehavior.PlayerBehaviorReference.SetSnapInfo(parentTree, transform, true, side);
		}

		void OnTriggerExit()
		{
			PlayerBehavior.PlayerBehaviorReference.SetSnapInfo(false);
		}
	}
}