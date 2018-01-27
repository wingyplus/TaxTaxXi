using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConfig : MonoBehaviour {

	public enum type {people,building};
	public type objtype;
	public string ID;

	// Use this for initialization
	void Start () {
		
	}

	public void Anim(){
		if (objtype == type.people) {
			
		} else {
		
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
