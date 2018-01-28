using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawer : MonoBehaviour
{
    public ObjectSpawner[] Spawners;
    public Transform[] taxi;
    public Sprite[] Sprites;

    public Sprite[] ManSprites;
    public Sprite[] BuildingSprites;

    public string[] _picktext;

    //private float taxiX;
    // Use this for initialization
    void Start()
    {
        for (int x = 0; x < 1; x++)
        {
            Spawners[x].PickSprites = new Sprite[Sprites.Length];
            Spawners[x]._picktext = new string[_picktext.Length];
            for (int y = 0; y < Spawners[x].PickSprites.Length; y++)
            {
                Spawners[x].PickSprites[y] = Sprites[y];
                Spawners[x]._picktext[y] = _picktext[y];
            }
        }

        Spawners[1].PickSprites = new Sprite[ManSprites.Length];
        Spawners[1]._picktext = new string[_picktext.Length];
        for (var i = 0; i < ManSprites.Length; i++)
        {
            Spawners[1].PickSprites[i] = ManSprites[i];
            Spawners[1]._picktext[i] = _picktext[i];
        }

        Spawners[2].PickSprites = new Sprite[BuildingSprites.Length];
        Spawners[2]._picktext = new string[_picktext.Length];
        for (var i = 0; i < BuildingSprites.Length; i++)
        {
            Spawners[2].PickSprites[i] = BuildingSprites[i];
            Spawners[2]._picktext[i] = _picktext[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (taxi[0].position.x < taxi[1].position.x)
        {
            for (int x = 0; x < Spawners.Length; x++)
            {
                Spawners[x].generationpoint = taxi[0];
                for (int y = 0; y < Spawners[x].ObjectSelfDestroyer.Count; y++)
                {
                    Spawners[x].ObjectSelfDestroyer[y].gameObject.GetComponent<ObjectSelfDestroyer>()
                        .SetObjectDestructionPoint(taxi[1].transform.GetChild(0).gameObject);
                }
            }
        }
        else
        {
            for (int x = 0; x < Spawners.Length; x++)
            {
                Spawners[x].generationpoint = taxi[1];
                for (int y = 0; y < Spawners[x].ObjectSelfDestroyer.Count; y++)
                {
                    Spawners[x].ObjectSelfDestroyer[y].gameObject.GetComponent<ObjectSelfDestroyer>()
                        .SetObjectDestructionPoint(taxi[0].transform.GetChild(0).gameObject);
                }
            }
        }
    }
}