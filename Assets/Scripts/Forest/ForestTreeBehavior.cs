﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Forest
{
	public class ForestTreeBehavior : MonoBehaviour 
	{
		private Rigidbody treeRigidbody;
		public ShowTreeCuts upperCutBlock;
		public ShowTreeCuts lowerCutBlock;

		Vector3 fallForcePosition;

		//generate this at runtime
		private float randomQuality;
		private QualityGrade qualityGrade;

		int[] sideCutsCount = new int[4] {0, 0, 0, 0};		//order: x_01, x_02, z_01, z_02
		private bool hasFallen = false;
		private bool isMarked = false;


		void Start()
		{
			treeRigidbody = GetComponent<Rigidbody>();
			fallForcePosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

			randomQuality = Random.value;
			if (randomQuality < .4)
			{
				qualityGrade = QualityGrade.F;
			}
			else if (randomQuality < .65)
			{
				qualityGrade = QualityGrade.D;
			}
			else if (randomQuality < .85)
			{
				qualityGrade = QualityGrade.C;
			}
			else if (randomQuality < .95)
			{
				qualityGrade = QualityGrade.B;
			}
			else
			{
				qualityGrade = QualityGrade.A;
			}
		}


		public bool HasFallen() { return hasFallen; }

		public void CutSide(int side)
		{
			int oppositeSide = side % 2 == 0 ? (side + 1) : (side - 1);
			int axisCount = sideCutsCount[side] + sideCutsCount[oppositeSide];

			if (axisCount < 9)
			{
				//prevents visual overcutting (vertices of any one side extending past 0 to their opposite side)
				upperCutBlock.CutFace(side);
				lowerCutBlock.CutFace(side);
				sideCutsCount[side] ++;
			}
			else
			{
				Fall(side);
			}
		}

		void Fall(int side)
		{
			int oppositeSide = side % 2 == 0 ? (side + 1) : (side - 1);

			int sideToFall = (sideCutsCount[side] >= sideCutsCount[oppositeSide]) ? side : oppositeSide;
			ApplyFallingForce(sideToFall);
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
