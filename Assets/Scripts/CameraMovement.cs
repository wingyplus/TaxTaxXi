using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Player;

    private Vector3 lastplayerposition;
    private float distancetomove;

    // Use this for initialization
    void Start () {
        lastplayerposition = Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        distancetomove = Player.transform.position.x - lastplayerposition.x;
        transform.position = new Vector3(transform.position.x + distancetomove, transform.position.y, transform.position.z);
        lastplayerposition = Player.transform.position;
    }
}
