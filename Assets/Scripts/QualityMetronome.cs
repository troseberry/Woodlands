using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityMetronome : MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip tone;
	public float[] pitches;

	int currentBeat = 0;

	public int bpm;
	float timer = 0;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= (60f / bpm))
		{
			audioSource.PlayOneShot(tone);
			SwitchPitch();
			timer = 0;
		}
	}

	void SwitchPitch()
	{
		currentBeat = (currentBeat + 1) % 2;
		audioSource.pitch = pitches[currentBeat];
	}
}
