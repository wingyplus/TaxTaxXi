using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public KeyCode[] InputKeys;
    public Vector3 Speed;
    public float Step;

    private bool _isMove;
    private Vector3 _carMove;

    void Start()
    {
        _isMove = false;
        _carMove = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
		if ((Input.GetKeyDown(InputKeys[0]) && _isMove) ||( Input.GetKeyDown(InputKeys[1]) && !_isMove))
        {
            _carMove = Speed;
			_isMove = !_isMove;
        }

        if (_carMove == Vector3.zero) return;

        _carMove = Vector3.MoveTowards(_carMove, Vector3.zero, Step * Time.deltaTime);
        transform.Translate(_carMove * Time.deltaTime);
    }
}