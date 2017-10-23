using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class FirewoodPileBehavior : MonoBehaviour 
	{
		void Start () 
		{
			UpdateFirewoodPile();
		}
		
		public void UpdateFirewoodPile()
		{
			int[] firewoodArray = HomesteadStockpile.GetAllFirewoodCount();
			int totalFirewod = 0;
			for (int i = 0; i < firewoodArray.Length; i++)
			{
				totalFirewod += firewoodArray[i];
			}

			transform.GetChild(0).gameObject.SetActive(totalFirewod > 0);
			transform.GetChild(1).gameObject.SetActive(totalFirewod > 10);
			transform.GetChild(2).gameObject.SetActive(totalFirewod > 25);
			transform.GetChild(3).gameObject.SetActive(totalFirewod > 50);
			transform.GetChild(4).gameObject.SetActive(totalFirewod > 100);
		}
	}
}
