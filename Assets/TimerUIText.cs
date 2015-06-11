using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerUIText : MonoBehaviour {


	float currentTime;
	Text time;

	// Use this for initialization
	void Start () {
	
		currentTime = 0.0f;
		time = GetComponent<Text>();



	}
	

	// Update is called once per frame
	void Update () {
		currentTime += 1*Time.deltaTime;
		time.text = "Time elapsed: " + Mathf.Round(currentTime * 100f) / 100f + "s";
	}
}
