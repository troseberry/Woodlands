using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;


namespace TreeFelling
{
	public class TreeFellingManager : MonoBehaviour 
	{
		public static TreeFellingManager ManagerReference;
		
		private bool wasSuccessful;

		private GameObject treeGroup;
		int treeCountGoal = 5;
		List<int> randomTrees = new List<int>();

		private int correctlyFelled = 0;
		private int incorrectlyFelled = 0;

		private Text treeCountText;

		public GameObject startButton;
		public GameObject returnButton;

		private bool contractStarted = false;


		void Start()
		{
			ManagerReference = this;
			treeGroup = GameObject.Find("Trees");

			treeCountText = GameObject.Find("CountText").GetComponent<Text>();
			treeCountText.text = "05";

			GameObject.Find("FreeLookCameraRig").GetComponent<FreeLookCam>().enabled = false;
			returnButton.SetActive(false);
		}

		void Update()
		{
			DebugPanel.Log("Correct Count: ", correctlyFelled);
			DebugPanel.Log("Incorrect Count: ", incorrectlyFelled);

			if (correctlyFelled == 5)
			{
				Timer.TreeFellingTimer.StopTimer();
				wasSuccessful = true;
				returnButton.SetActive(true);
			}
			if (incorrectlyFelled == 3)
			{
				Timer.TreeFellingTimer.StopTimer();
				wasSuccessful = false;
				returnButton.SetActive(true);
			}
			if (contractStarted && Timer.TreeFellingTimer.GetTime() == 0)
			{
				Debug.Log("Check");
				Timer.TreeFellingTimer.StopTimer();
				wasSuccessful = false;
				returnButton.SetActive(true);
			}
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
			GenerateRandomNumbers(treeCountGoal);

			for (int i = 0; i < randomTrees.Count; i++)
			{
				treeGroup.transform.GetChild(randomTrees[i]).GetComponent<TreeBehavior>().EnableLumberTag();
			}
		}

		public void IncrementCorrectCount()
		{ 
			correctlyFelled++;
			treeCountText.text = string.Format("{0:00}", 5 - correctlyFelled);
		}

		public void IncrementIncorrectCount() { incorrectlyFelled++; }


		public void StartContract()
		{
			MarkRandomTrees();
			Timer.TreeFellingTimer.ResetTimer();
			GameObject.Find("FreeLookCameraRig").GetComponent<FreeLookCam>().enabled = true;
			contractStarted = true;
			startButton.SetActive(false);
			
		}

		public void PayoutAndReturn()
		{
			if (wasSuccessful) ContractGameInfo.GetPayout().AddToInventory();
			SceneNavigation.ToHomestead();
		}
	}
}
