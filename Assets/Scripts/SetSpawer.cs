using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawer : MonoBehaviour {

	public ObjectSpawner[] _OS;
	public Transform[] taxi;
	//private float taxiX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (taxi [0].position.x < taxi[1].position.x) {
			for(int x = 0 ;x < _OS.Length;x++){
				_OS[x].generationpoint = taxi [0];
				for(int y = 0 ;y < _OS[x].ObjectSelfDestroyer.Count;y++){
					_OS[x].ObjectSelfDestroyer[y].gameObject.GetComponent<ObjectSelfDestroyer>().SetObjectDestructionPoint(taxi [1].transform.GetChild(0).gameObject);
				}
			}
		} else {
			for(int x = 0 ;x < _OS.Length;x++){
				_OS[x].generationpoint = taxi [1];
				for(int y = 0 ;y < _OS[x].ObjectSelfDestroyer.Count;y++){
					_OS[x].ObjectSelfDestroyer[y].gameObject.GetComponent<ObjectSelfDestroyer>().SetObjectDestructionPoint(taxi [0].transform.GetChild(0).gameObject);
				}
			}
		}
	}
}
