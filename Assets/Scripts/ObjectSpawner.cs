using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public Transform generationpoint;
    public float distance;

    public float distancemin;
    public float distancemax;

    private int selector;
    private int startselector;
    private float[] objectswidth;
    private Vector3 newObjectPos;

    public ObjectPooler[] ObjectPool;
    public GameObject ObjectDestroyReference;

    void Start()
    {
        objectswidth = new float[ObjectPool.Length];
        for (int i = 0; i < ObjectPool.Length; i++)
        {
            objectswidth[i] = ObjectPool[i].pooledObject.GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

	public  List<ObjectSelfDestroyer> ObjectSelfDestroyer;
    void Update()
    {
        // Spawn new object offscreen
        if (transform.position.x + Screen.width/20 > generationpoint.position.x)
        {
            startselector = Random.Range(0, ObjectPool.Length);
            selector = Random.Range(0, ObjectPool.Length);
            distance = Random.Range(distancemin, distancemax);

            // Do not spawn object to overlap each other
            newObjectPos = new Vector3(transform.position.x - (objectswidth[startselector] / 2) - distance, transform.position.y, transform.position.z);
            if(!isNewObjectOverlap(newObjectPos, objectswidth[selector]))
            {
                GameObject startPlatform = ObjectPool[startselector].GetPooledObject();
                transform.position = newObjectPos;
                startPlatform.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                startPlatform.transform.rotation = transform.rotation;
                startPlatform.SetActive(true);
                transform.position = new Vector3(transform.position.x - (objectswidth[selector] / 2), transform.position.y, transform.position.z);
				ObjectSelfDestroyer.Add (startPlatform.GetComponent<ObjectSelfDestroyer> ());
				ObjectSelfDestroyer[ObjectSelfDestroyer.Count-1].SetObjectDestructionPoint(ObjectDestroyReference);
				//startPlatform.GetComponent<ObjectSelfDestroyer> ();

				//ObjectSelfDestroyer.SetObjectDestructionPoint(ObjectDestroyReference);
            }
        }
    }

    bool isNewObjectOverlap(Vector3 newObjectPos, float newObjectWidth)
    {
        bool isOverlapping = false;

        //Check left and right boundary of new object
        newObjectPos.x -= newObjectWidth;
        if (Physics2D.Raycast(newObjectPos, transform.TransformDirection(Vector3.forward), 10))
        {
            isOverlapping = true;
        }

        newObjectPos.x += newObjectWidth * 2;
        if (Physics2D.Raycast(newObjectPos, transform.TransformDirection(Vector3.forward), 10))
        {
            isOverlapping = true;
        }

        return isOverlapping;
    }
}
