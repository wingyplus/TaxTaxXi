using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

	public enum OnTriggeris {Enter,Exit,Stay};
	public OnTriggeris step = OnTriggeris.Enter;
	public string tagofObj;
	public float counttime;
	private float forpickup;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		//In 
		tagofObj = other.tag;
		forpickup = counttime;
		step = OnTriggeris.Enter;
	}

	void OnTriggerExit2D(Collider2D other) {
		//Out

		step = OnTriggeris.Exit;
	}

	void OnTriggerStay2D(Collider2D other) {
		//Stay

		step = OnTriggeris.Stay;
	}
	// Update is called once per frame
	void Update () {
		if (step == OnTriggeris.Stay) {
			if (forpickup >= 0) {
				forpickup -= Time.deltaTime;
			} else {
				if(tagofObj == "people")
				Debug.Log ("pickup");
				else if(tagofObj == "building")
					Debug.Log ("sendpeople");
			}
		}
	}
}
