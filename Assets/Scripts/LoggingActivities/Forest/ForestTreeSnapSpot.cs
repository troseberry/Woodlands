using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Forest
{
	public class ForestTreeSnapSpot : MonoBehaviour 
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
				
				LoggingActivityPlayerBehavior.SetSnapInfo(parentTree, transform, true, side);
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				LoggingActivityPlayerBehavior.SetSnapInfo(false);
			}
		}
	}
}