﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public KeyCode[] InputKeys;
    public float Speed;
    public float MaxVelocity;
    public float Fraction;
    public Text Money;

    private bool _isMove, _acceptInput;
    private Vector3 _carMove;
    private float _velocity;
	public ParticleSystem[] effectsmoke;

    public AudioSource engineSound;
    private float audioSpeed = 10.0f;

    void Start()
    {
        _acceptInput = true;
        _isMove = false;
        _carMove = Vector3.zero;
        _velocity = 0f;

        Money.GetComponent<MoneyComponent>().ResetAmount();
    }

    // Update is called once per frame
    void Update()
    {
        if (_acceptInput)
        {

            if ((Input.GetKeyDown(InputKeys[0]) && _isMove) || (Input.GetKeyDown(InputKeys[1]) && !_isMove))
            {
                _isMove = !_isMove;

                // dont't add more velocity when reach MaxVelocity
                if (_velocity + Speed <= MaxVelocity)
                {
                    _velocity += Speed;
                }
            }

            if (_velocity > 0)
            {
                _carMove = new Vector3(_velocity * -1.0f, 0, 0);
                transform.Translate(_carMove * Time.deltaTime);
                _velocity -= Fraction;
                if (effectsmoke[0].isStopped)
                {
                    effectsmoke[0].Play();
                    //effectsmoke [1].Play ();
                }

                engineSound.pitch = 2;
            }
            else
            {
                if (effectsmoke[0].isPlaying)
                {
                    effectsmoke[0].Stop();
                    //effectsmoke [1].Stop ();
                }
                _velocity = 0f;

                engineSound.pitch = 1;
            }
        }
    }

    public float GetCarVelocity()
    {
        return _velocity;
    }

    public void forceGameOver()
    {
        _acceptInput = false;
        _velocity = 0f;
    }
}