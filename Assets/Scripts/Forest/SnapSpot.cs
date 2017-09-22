using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Forest
{
	public class SnapSpot : MonoBehaviour 
	{
		private ForestTreeBehavior parentTree;

		void Start()
		{
			parentTree = transform.parent.GetComponent<ForestTreeBehavior>();
		}

		void OnTriggerEnter(Collider other)
		{	
			if (other.tag.Equals("Player"))
			{
				if (name.Contains("TreeSnap"))
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
				else if (name.Contains("LogSnap"))
				{
					LogBuckingPlayerBehavior.LogBuckingPBRef.SetSnapInfo(transform, true);
				}
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				if (name.Contains("TreeSnap"))
				{
					ForestPlayerBehavior.PlayerBehaviorReference.SetSnapInfo(false);
				}
				else if (name.Contains("LogSnap"))
				{
					LogBuckingPlayerBehavior.LogBuckingPBRef.SetSnapInfo(false);
				}
			}
		}
	}
}