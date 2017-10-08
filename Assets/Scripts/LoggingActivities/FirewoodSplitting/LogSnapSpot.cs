using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class LogSnapSpot : MonoBehaviour 
	{
		private LogBehavior parentLog;

		void Start () 
		{
			parentLog = transform.parent.GetComponent<LogBehavior>();
		}
		
		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				LoggingActivityPlayerBehavior.SetSnapInfo(parentLog, transform, true);
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
