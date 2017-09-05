using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Forest
{
	public class ForestTreeBehavior : MonoBehaviour 
	{
		int[] sideCutsCount = new int[4] {5, 5, 5, 5};		//order: x_01, x_02, z_01, z_02
		private bool hasFallen = false;
		private bool isMarked = false;

		public bool HasFallen() { return hasFallen; }

		public void cutSide(int side)
		{
			if (sideCutsCount[side] > 0)
			{
				sideCutsCount[side] --;
				Debug.Log("Sides: " 
				+ sideCutsCount[0] + " | " 
				+ sideCutsCount[1] + " | "
				+ sideCutsCount[2] + " | "
				+ sideCutsCount[3]);

				if (sideCutsCount[side] == 0) Fall(side);
			}
		}

		void Fall(int side)
		{
			//wanna change this to be physics based. and give trees rigidbodies

			int oppositeSide = side % 2 == 0 ? (side + 1) : (side - 1);
			if (sideCutsCount[oppositeSide] <= 2)
			{
				//fall away
				SetFallTowardsPosition(oppositeSide);
			}
			else{
				//fall towards
				SetFallTowardsPosition(side);
			}
			hasFallen = true;


			foreach (SnapSpot snap in transform.GetComponentsInChildren<SnapSpot>())
			{
				snap.enabled = false;
			}
			ForestPlayerBehavior.PlayerBehaviorReference.UnsnapPlayer();
			GetComponent<ForestTreeBehavior>().enabled = false;

			//add to homestead stockpile
		}

		void SetFallTowardsPosition(int side)
		{
			switch (side)
			{
				case 0:
					transform.eulerAngles = new Vector3(0, 0, 90);
					transform.position = new Vector3(transform.position.x - 1.5f, .4f, transform.position.z);
					break;
				case 1:
					transform.eulerAngles = new Vector3(0, 0, -90);
					transform.position = new Vector3(transform.position.x + 1.5f, .4f, transform.position.z);
					break;
				case 2:
					transform.eulerAngles = new Vector3(90, 0, 0);
					transform.position = new Vector3(transform.position.x, .4f, transform.position.z - 1.5f);
					break;
				case 3:
					transform.eulerAngles = new Vector3(-90, 0, 0);
					transform.position = new Vector3(transform.position.x, .4f, transform.position.z + 1.5f);
					break;
			}
		}

		public void EnableLumberTag()
		{
			int randomTag = Random.Range(0, 4);
			transform.Find("LumberTags").GetChild(randomTag).gameObject.SetActive(true);
			isMarked = true;
		}
	}
}
