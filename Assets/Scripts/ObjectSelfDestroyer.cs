using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelfDestroyer : MonoBehaviour {

    public GameObject objectDestructionpoint;

    // Use this for initialization
    void Start()
    {
        objectDestructionpoint = GameObject.Find("ObjectDestructionCheck");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > objectDestructionpoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
