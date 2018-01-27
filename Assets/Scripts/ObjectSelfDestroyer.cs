using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelfDestroyer : MonoBehaviour {

    public GameObject objectDestructionpoint;

    void Update()
    {
        if (transform.position.x > objectDestructionpoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetObjectDestructionPoint(GameObject referenceObject)
    {
        objectDestructionpoint = referenceObject ;
    }
}
