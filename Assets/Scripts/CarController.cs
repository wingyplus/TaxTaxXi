using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public KeyCode[] InputKeys;
    public float Speed;
    public float Fraction;

    private bool _isMove;
    private Vector3 _carMove;
    private float _velocity;

    void Start()
    {
        _isMove = false;
        _carMove = Vector3.zero;
        _velocity = 0f;
    }


    // Update is called once per frame
    void Update()
    {
		if ((Input.GetKeyDown(InputKeys[0]) && _isMove) ||( Input.GetKeyDown(InputKeys[1]) && !_isMove))
        {
			_isMove = !_isMove;
            _velocity += Speed;
        }

        if (_velocity > 0)
        {
            _carMove = new Vector3(_velocity * -1.0f, 0, 0);
            transform.Translate(_carMove * Time.deltaTime);
            _velocity -= Fraction;
        }
        else
        {
            _velocity = 0f;
        }
    }

    public float GetCarVelocity()
    {
        return _velocity;
    }
}