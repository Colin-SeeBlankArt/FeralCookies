//https://www.youtube.com/watch?v=qc7J0iei3BU&t=256s

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
	public static TimeController instance;
	
	public Text timeCounter;
		
	private TimeSpan timePlaying;
	private bool timeGoing;
	
	public float elapsedTime; 
	
	void Awake()
	{
		instance = this;  // This allows for calling Time functions from other scripts
	}
	
	void Start()
	{
		timeCounter.text = "Time: 00:00.00";
		timeGoing = false;
	}
	
	public void BeginTimer()
	{
		timeGoing = true;
		elapsedTime = 0f;
		
		StartCoroutine(UpdateTimer());		
	}
	
	public void EndTimer()
	{
		timeGoing = false;
	}
	
	private IEnumerator UpdateTimer()
	{
		while (timeGoing)
		{
			elapsedTime += Time.deltaTime;
			timePlaying = TimeSpan.FromSeconds(elapsedTime);
			string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.ff");
			timeCounter.text = timePlayingStr; 
			yield return null;
			
		}
		
		
	}

}

	
	