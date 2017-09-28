using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogBucking
{
	public class LogSnapSpot : MonoBehaviour 
	{
		private LogBuckingTreeBehavior parentLog;
		int location;

		void Start () 
		{
			location = name.Contains("01") ? 0 : 1;
			parentLog = transform.parent.GetComponent<LogBuckingTreeBehavior>();
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				LogBuckingPlayerBehavior.LogBuckingPBRef.SetSnapInfo(parentLog, transform, true, location);
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				LogBuckingPlayerBehavior.LogBuckingPBRef.SetSnapInfo(false);
			}
		}

		
	}
}
