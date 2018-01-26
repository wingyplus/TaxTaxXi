using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public KeyCode[] InputKeys;
    private bool IsMove;
    public Vector3 Speed;
    public float Step;
    private Vector3 CarMove;

    void Start()
    {
        IsMove = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(InputKeys[0]) && IsMove || Input.GetKeyDown(InputKeys[1]) && !IsMove)
        {
            CarMove = Speed;
        }

        if (CarMove == Vector3.zero) return;

        CarMove = Vector3.MoveTowards(CarMove, Vector3.zero, Step * Time.deltaTime);
        transform.Translate(CarMove * Time.deltaTime);
    }
}