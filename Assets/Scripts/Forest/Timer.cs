using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TreeFelling
{
	public class Timer : MonoBehaviour 
	{
		public static Timer TreeFellingTimer;

		private Text timerText;
		private float timer;
		private string formattedTimer;
		private bool stopTimer = false;

		void Start () 
		{
			TreeFellingTimer = this;
			timerText = GetComponent<Text>();
			timer = 0f;
		}
		
		void Update () 
		{
			if (!stopTimer)
			{
				if (timer > 0)
				{
					timer -= Time.deltaTime;
				}
				else
				{
					timer = 0f;
				}
			}
			formattedTimer = string.Format("{0:00.00}", timer % 60);
            timerText.text = formattedTimer;
		}

		public void StopTimer()
		{
			stopTimer = true;
		}

		public void StartTimer()
		{
			stopTimer = false;
		}

		public void ResetTimer()
		{
			timer = 45f;
			stopTimer = false;
		}

		public float GetTime()
		{
			return timer;
		}
	}
}
