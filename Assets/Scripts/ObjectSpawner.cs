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

    public ObjectPooler[] ObjectPool;

    void Start()
    {
        objectswidth = new float[ObjectPool.Length];
        for (int i = 0; i < ObjectPool.Length; i++)
        {
            objectswidth[i] = ObjectPool[i].pooledObject.GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void Update()
    {
        // Spawn new object offscreen
        if (transform.position.x + Screen.width/20 > generationpoint.position.x)
        {
            startselector = Random.Range(0, ObjectPool.Length);
            selector = Random.Range(0, ObjectPool.Length);
            distance = Random.Range(distancemin, distancemax);

            // Do not spawn object to overlap each other
            GameObject startPlatform = ObjectPool[startselector].GetPooledObject();
            transform.position = new Vector3(transform.position.x - (objectswidth[startselector] / 2) - distance, transform.position.y, transform.position.z);
            startPlatform.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            startPlatform.transform.rotation = transform.rotation;
            startPlatform.SetActive(true);
            transform.position = new Vector3(transform.position.x - (objectswidth[selector] / 2), transform.position.y, transform.position.z);
        }
    }
}
