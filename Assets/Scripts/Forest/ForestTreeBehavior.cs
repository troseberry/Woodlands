﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Forest
{
	public class ForestTreeBehavior : MonoBehaviour 
	{
		private Rigidbody treeRigidbody;

		Vector3 fallForcePosition;

		//generate this at runtime
		private QualityGrade qualityGrade = QualityGrade.F;

		int[] sideCutsCount = new int[4] {5, 5, 5, 5};		//order: x_01, x_02, z_01, z_02
		private bool hasFallen = false;
		private bool isMarked = false;


		void Start()
		{
			treeRigidbody = GetComponent<Rigidbody>();
			fallForcePosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
		}


		public bool HasFallen() { return hasFallen; }

		public void cutSide(int side)
		{
			if (sideCutsCount[side] > 0)
			{
				sideCutsCount[side] --;
				// Debug.Log("Sides: " 
				// + sideCutsCount[0] + " | " 
				// + sideCutsCount[1] + " | "
				// + sideCutsCount[2] + " | "
				// + sideCutsCount[3]);

				if (sideCutsCount[side] == 0) Fall(side);
			}
		}

		void Fall(int side)
		{
			int oppositeSide = side % 2 == 0 ? (side + 1) : (side - 1);
			if (sideCutsCount[oppositeSide] <= 2)
			{
				//fall away
				ApplyFallingForce(oppositeSide);
			}
			else{
				//fall towards
				ApplyFallingForce(side);
			}
			hasFallen = true;


			foreach (SnapSpot snap in transform.GetComponentsInChildren<SnapSpot>())
			{
				snap.enabled = false;
			}
			ForestPlayerBehavior.PlayerBehaviorReference.UnsnapPlayer();
			GetComponent<ForestTreeBehavior>().enabled = false;

			HomesteadStockpile.UpdateTreesCountAtGrade(qualityGrade, 1);

			//Visually phase tree out
			Invoke("PhaseOutTree", 5);
		}

		void ApplyFallingForce(int side)
		{
			
			treeRigidbody.constraints = RigidbodyConstraints.None;
			switch (side)
			{
				case 0:
					treeRigidbody.AddForceAtPosition(transform.right * -1, fallForcePosition, ForceMode.Impulse);
					break;
				case 1:
					treeRigidbody.AddForceAtPosition(transform.right * 1, fallForcePosition, ForceMode.Impulse);
					break;
				case 2:
					treeRigidbody.AddForceAtPosition(transform.forward * -1, fallForcePosition, ForceMode.Impulse);
					break;
				case 3:
					treeRigidbody.AddForceAtPosition(transform.forward * 1, fallForcePosition, ForceMode.Impulse);
					break;
			}
		}

		public void EnableLumberTag()
		{
			int randomTag = Random.Range(0, 4);
			transform.Find("LumberTags").GetChild(randomTag).gameObject.SetActive(true);
			isMarked = true;
		}


		void PhaseOutTree()
		{
			Destroy(gameObject);
		}
	}
}
