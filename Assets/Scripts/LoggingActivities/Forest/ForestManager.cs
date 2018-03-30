using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;


namespace Forest
{
	public class ForestManager : MonoBehaviour 
	{
		public static ForestManager ForestManagerReference;

		private GameObject treeGroup;
		List<int> randomTrees = new List<int>();


		void Start()
		{
			ForestManagerReference = this;
			treeGroup = GameObject.Find("Trees");
		}

		void Update()
		{

		}


		//should eventually look at difficulty --> determine number to mark
		void GenerateRandomNumbers(int count)
		{
			int counter = 0;
			while(counter < 5)
			{
				int toAdd = Random.Range(0, treeGroup.transform.childCount);
				if (!randomTrees.Contains(toAdd))
				{
					randomTrees.Add(toAdd);
					counter++;
				}
			}
		}

		void MarkRandomTrees()
		{
			GenerateRandomNumbers(5);

			for (int i = 0; i < randomTrees.Count; i++)
			{
				treeGroup.transform.GetChild(randomTrees[i]).GetComponent<ForestTreeBehavior>().EnableLumberTag();
			}
		}
	}
}
