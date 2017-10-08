using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogBucking
{
	public class FelledTreeSnapSpot : MonoBehaviour 
	{
		private FelledTreeBehavior parentFelledTree;
		int location;

		void Start () 
		{
			location = name.Contains("01") ? 0 : 1;
			parentFelledTree = transform.parent.GetComponent<FelledTreeBehavior>();
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				LoggingActivityPlayerBehavior.SetSnapInfo(parentFelledTree, transform, true, location);
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
