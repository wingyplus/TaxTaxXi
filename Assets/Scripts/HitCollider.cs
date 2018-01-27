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

    // PassengerState is state what taxi has passenger or not.
    private enum PickupState
    {
        Pick,
        Empty
    }

    public OnTriggeris step = OnTriggeris.Enter;
    private string _targetTagName;
    public float counttime;
    private float forpickup;
    public CarController _CarController;

    //pick people
    private string _peopleId;
    private PickupState _pickupState;
    private ObjectConfig _objectConfig;

    public UnityEngine.UI.Text Money;
    private MoneyComponent _moneyComponent;

    // Use this for initialization
    void Start()
    {
        _pickupState = PickupState.Empty;
        _moneyComponent = Money.GetComponent<MoneyComponent>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //In
        _targetTagName = other.tag;
        forpickup = counttime;
        if (_objectConfig == null)
            _objectConfig = other.GetComponent<ObjectConfig>();

        step = OnTriggeris.Enter;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Out
        if (_objectConfig == other.GetComponent<ObjectConfig>())
            _objectConfig = null;

        step = OnTriggeris.Exit;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Stay
        if (_objectConfig == null)
            _objectConfig = other.GetComponent<ObjectConfig>();

        step = OnTriggeris.Stay;
    }

    // Update is called once per frame
    void Update()
    {
        // not hit anything, skip it now.
        if (_objectConfig == null)
        {
            return;
        }

        if (step == OnTriggeris.Stay && _CarController.GetCarVelocity() == 0)
        {
            if (forpickup >= 0)
            {
                forpickup -= Time.deltaTime;
                return;
            }

            switch (_targetTagName)
            {
                case "people":
                    HandlePassengerState();
                    break;
                case "building":
                    HandleBuildingState();
                    break;
            }
        }
    }

    private void HandlePassengerState()
    {
		_moneyComponent.ok.Play ();
        if (_pickupState != PickupState.Empty) return;

        Debug.Log("pickup");
        _peopleId = _objectConfig.ID;
        GetComponent<DriverSound>().PlayPickUpSound();
        _objectConfig.gameObject.SetActive(false);

        // taxi pick passenger.
        _pickupState = PickupState.Pick;
    }

    private void HandleBuildingState()
    {
        if (_pickupState != PickupState.Pick) return;

        Debug.Log("sent passenger");

        if (_peopleId == _objectConfig.ID)
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

        // taxi has not passenger.
        _pickupState = PickupState.Empty;
    }
}