using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogBucking
{
	public class TreePileBehavior : MonoBehaviour 
	{
		QualityGrade qualityGrade;

		public GameObject interactableTree;
		public Transform treePileGroup;
		// public DisplayGradeUI gradeUI;

		void Start () 
		{
			switch(name)
			{
				case "LogBucking_GradeA":
					qualityGrade = QualityGrade.A;
					break;
				case "LogBucking_GradeB":
					qualityGrade = QualityGrade.B;
					break;
				case "LogBucking_GradeC":
					qualityGrade = QualityGrade.C;
					break;
				case "LogBucking_GradeD":
					qualityGrade = QualityGrade.D;
					break;
				case "LogBucking_GradeF":
					qualityGrade = QualityGrade.F;
					break;
			}

			UpdateTreePile();
		}
		
		void Update () 
		{
			
		}

		public void UpdateTreePile()
		{
			int treesCount = HomesteadStockpile.GetTreesCountAtGrade(qualityGrade);

			if (treesCount == 0 && interactableTree.activeSelf) GetComponentInChildren<DisplayGradeUI>().HideUI();

			interactableTree.SetActive(treesCount > 0);

			treePileGroup.GetChild(0).gameObject.SetActive(treesCount > 6);
			treePileGroup.GetChild(1).gameObject.SetActive(treesCount > 5);
			treePileGroup.GetChild(2).gameObject.SetActive(treesCount > 4);
			treePileGroup.GetChild(3).gameObject.SetActive(treesCount > 3);
			treePileGroup.GetChild(4).gameObject.SetActive(treesCount > 2);
			treePileGroup.GetChild(5).gameObject.SetActive(treesCount > 1);
		}
	}
}
