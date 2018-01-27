using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectConfig : MonoBehaviour {

	public enum type {people,building};
	public type objtype;
	public int ID;
	public TextMesh UIname;

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
