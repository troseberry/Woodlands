using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class LogSnapSpot : MonoBehaviour 
	{
		private LogBehavior parentLog;
		int index;

		void Start () 
		{
			parentLog = transform.parent.GetComponent<LogBehavior>();
			index = transform.parent.parent.GetSiblingIndex();
		}
		
		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				LoggingActivityPlayerBehavior.SetSnapInfo(parentLog, transform, true, index);
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
