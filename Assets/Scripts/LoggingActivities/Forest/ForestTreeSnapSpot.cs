using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Forest
{
	public class ForestTreeSnapSpot : MonoBehaviour 
	{
		private ForestTreeBehavior parentTree;
		private Transform playerTransform;

		void Start()
		{
			parentTree = transform.parent.GetComponent<ForestTreeBehavior>();;
		}

		void OnTriggerEnter(Collider other)
		{	
			if (other.tag.Equals("Player") && !name.Equals("ProximityTrigger"))
			{
				int side = 0;
				switch(name)
				{
					case "snap_01":
						side = 0;
						break;
					case "snap_02":
						side = 3;
						break;
					case "snap_03":
						side = 1;
						break;
					case "snap_04":
						side = 2;
						break;
				}
				LoggingActivityPlayerBehavior.SetSnapInfo(parentTree, transform, true, side);
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.tag.Equals("Player") && name.Equals("ProximityTrigger"))
			{
				LoggingActivityPlayerBehavior.SetSnapInfo(false);

			}
		}
	}
}