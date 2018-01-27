using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text screentime;
	public Text screentime1;
	public float starttime;
	public float time;
	public float countdown;
	public bool count;


	// Use this for initialization
	void Start () {
		time = starttime;
	}
	
	// Update is called once per frame
	void Update () {

		if(count){
		time -= countdown * Time.deltaTime;
		screentime.text = "Timer : " + Mathf.Round (time);
		screentime1.text = "Timer : " + Mathf.Round (time);
		}

		if (time <= 0) {
			count = false;
		}
	}
}
