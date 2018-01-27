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
    public string tagofObj;
    public float counttime;
    private float forpickup;
    public CarController _CarController;

    //pick people
    public string IDpeople;
    public bool canpickup;
    private ObjectConfig _ObjectConfig;

    public UnityEngine.UI.Text Money;
    private MoneyComponent _moneyComponent;

    // Use this for initialization
    void Start()
    {
        canpickup = true;
        _moneyComponent = Money.GetComponent<MoneyComponent>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //In
        tagofObj = other.tag;
        forpickup = counttime;
        if (_ObjectConfig == null)
            _ObjectConfig = other.GetComponent<ObjectConfig>();

        step = OnTriggeris.Enter;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Out
        if (_ObjectConfig == other.GetComponent<ObjectConfig>())
            _ObjectConfig = null;

        step = OnTriggeris.Exit;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Stay
        if (_ObjectConfig == null)
            _ObjectConfig = other.GetComponent<ObjectConfig>();

        step = OnTriggeris.Stay;
    }

    // Update is called once per frame
    void Update()
    {
        if (step == OnTriggeris.Stay && _CarController.GetCarVelocity() == 0 && _ObjectConfig != null)
        {
            if (forpickup >= 0)
            {
                forpickup -= Time.deltaTime;
            }
            else
            {
                if (tagofObj == "people" && canpickup)
                {
                    Debug.Log("pickup");
                    IDpeople = _ObjectConfig.ID;
                    GetComponent<DriverSound>().PlayPickUpSound();
                    _ObjectConfig.gameObject.SetActive(false);
                    canpickup = false;
                }
                else if (tagofObj == "building" && !canpickup)
                {
                    Debug.Log("sendpeople");
                    canpickup = true;
                    if (IDpeople == _ObjectConfig.ID)
                    {
                        // +100 score
                        _moneyComponent.AddMoney(100);
                        GetComponent<DriverSound>().PlaySentSound();
                    }
                    else
                    {
                        // -100 score
                        _moneyComponent.DeductMoney(100);
                        GetComponent<DriverSound>().PlayLosingSound();
                    }
                }
            }
        }
    }
}