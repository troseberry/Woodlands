using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogBucking
{
	public class FelledTreePileBehavior : MonoBehaviour 
	{
		QualityGrade qualityGrade;

		public GameObject interactableFelledTree;
		public Transform felledTreePileGroup;

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
			UpdateFelledTreePile();
		}

		public void UpdateFelledTreePile()
		{
			int treesCount = HomesteadStockpile.GetTreesCountAtGrade(qualityGrade);

			interactableFelledTree.SetActive(treesCount > 0);

			felledTreePileGroup.GetChild(0).gameObject.SetActive(treesCount > 6);
			felledTreePileGroup.GetChild(1).gameObject.SetActive(treesCount > 5);
			felledTreePileGroup.GetChild(2).gameObject.SetActive(treesCount > 4);
			felledTreePileGroup.GetChild(3).gameObject.SetActive(treesCount > 3);
			felledTreePileGroup.GetChild(4).gameObject.SetActive(treesCount > 2);
			felledTreePileGroup.GetChild(5).gameObject.SetActive(treesCount > 1);
		}
	}
}
