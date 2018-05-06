using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	public Text timerText;
	private float time = 0;

	public bool keepTiming;
	 
	void Start ()
	{
		StartCoundownTimer();
		keepTiming = true;
	}
	 
	void StartCoundownTimer()
	{
		if (timerText != null)
		{
			time = 0;
			timerText.text = "Time: 00:00:000";
			InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
		}
	}
	 
	void UpdateTimer()
	{
		if (timerText != null && keepTiming)
		{
			time += Time.deltaTime;
			string minutes = Mathf.Floor(time / 60).ToString("00");
			string seconds = (time % 60).ToString("00");
			string fraction = ((time * 100) % 100).ToString("000");
			timerText.text = "Time: " + minutes + ":" + seconds + ":" + fraction;
		}
	}
}
