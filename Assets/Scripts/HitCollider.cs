using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public enum OnTriggeris
    {
        Enter,
        Exit,
        Stay
    };

    public OnTriggeris step = OnTriggeris.Enter;
    public string TagOfObject;
    public float counttime;
    private float forpickup;
    public CarController _CarController;
    
    public UnityEngine.UI.Text Money;
    private MoneyComponent _moneyComponent;

    // Use this for initialization
    void Start()
    {
        _moneyComponent = Money.GetComponent<MoneyComponent>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //In 
        TagOfObject = other.tag;
        forpickup = counttime;
        step = OnTriggeris.Enter;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Out

        step = OnTriggeris.Exit;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Stay

        step = OnTriggeris.Stay;
    }

    // Update is called once per frame
    void Update()
    {
        if (step == OnTriggeris.Stay && _CarController.GetCarVelocity() == 0)
        {
            if (forpickup >= 0)
            {
                forpickup -= Time.deltaTime;
            }
            else
            {
                if (TagOfObject == "people")
                    Debug.Log("pickup");
                else if (TagOfObject == "building")
                    _moneyComponent.AddMoney(100);
                    Debug.Log("sendpeople");
            }
        }
    }
}