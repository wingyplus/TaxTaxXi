using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text screentime;
    public float timer;

    private float remainingTime;
	private bool count;


	// Use this for initialization
	void Start () {
        remainingTime = timer;
        count = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(count){
            remainingTime -= Time.deltaTime;
		    screentime.text = Mathf.Round (remainingTime).ToString();
		}

		if (remainingTime <= 0) {
			count = false;
		}
	}
}
