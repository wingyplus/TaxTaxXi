using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public KeyCode[] input_car;
    private bool move;
    public Vector3 speed_car;
    public float step;
    private Vector3 carmove;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(input_car[0]) && move)
        {
            carmove = speed_car;
        }
        else if (Input.GetKeyDown(input_car[1]) && !move)
        {
            carmove = speed_car;
            //transform.Translate(carmove * Time.deltaTime);
        }
        if (carmove != Vector3.zero)
        {
            carmove = Vector3.MoveTowards(speed_car, Vector3.zero, step * Time.deltaTime);
            transform.Translate(carmove * Time.deltaTime);
        }

    }
}