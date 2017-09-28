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
		private DisplayGradeUI gradeUI;

		void Start () 
		{
			switch(name)
			{
				case "GradeA":
					qualityGrade = QualityGrade.A;
					break;
				case "GradeB":
					qualityGrade = QualityGrade.B;
					break;
				case "GradeC":
					qualityGrade = QualityGrade.C;
					break;
				case "GradeD":
					qualityGrade = QualityGrade.D;
					break;
				case "GradeF":
					qualityGrade = QualityGrade.F;
					break;
			}
			gradeUI = GetComponentInChildren<DisplayGradeUI>();
			UpdateTreePile();
		}

		public void UpdateTreePile()
		{
			int treesCount = HomesteadStockpile.GetTreesCountAtGrade(qualityGrade);

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
