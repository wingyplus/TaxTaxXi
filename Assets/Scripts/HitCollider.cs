using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCollider : MonoBehaviour
{
<<<<<<< HEAD
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
=======
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
		Empty,
		Kick
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

	public Text Money;
	private MoneyComponent _moneyComponent;

	public TextMesh MessageBoxMinus;
	public string[] Minus_Message;
	public TextMesh MessageBoxPlus;
	public string[] Plus_Message;
	public TextMesh MessageBox_dontpick;
	public string[] dontpick_Message;

	// Use this for initialization
	void Start()
	{
		_pickupState = PickupState.Empty;
		_moneyComponent = Money.GetComponent<MoneyComponent>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//In

		forpickup = counttime;
		if ((_objectConfig == null && _pickupState == PickupState.Empty && other.tag == "people") ||
		    (_objectConfig == null && _pickupState == PickupState.Pick && other.tag == "building")) {
			_targetTagName = other.tag;
			_objectConfig = other.GetComponent<ObjectConfig> ();
		}

		step = OnTriggeris.Enter;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		// taxi has passenger and drive over building
		Debug.Log("Exit "+other.name);
		if (_targetTagName == "building" && _peopleId != string.Empty && _pickupState == PickupState.Pick ) {
			if(_peopleId == _objectConfig.ID.ToString()){
			Debug.Log ("pickup state: kick");
			// kick passenger
				_pickupState = PickupState.Kick;
			}
			//StartCoroutine (countsetMessageBox(_pickupState));
		} 
		if (other.tag == "people" && _pickupState == PickupState.Empty) {
			Debug.Log ("pickup state: Don't pick");
			other.gameObject.GetComponent<ObjectConfig> ().Anim ();
			StartCoroutine (countsetMessageBox(_pickupState));
		}

		//Out
		if (_objectConfig == other.GetComponent<ObjectConfig>())
			_objectConfig = null;

		step = OnTriggeris.Exit;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		//Stay
		if ((_objectConfig == null && _pickupState == PickupState.Empty && other.tag == "people") ||
			(_objectConfig == null && _pickupState == PickupState.Pick && other.tag == "building")) {
			_targetTagName = other.tag;
			_objectConfig = other.GetComponent<ObjectConfig> ();
		}
		step = OnTriggeris.Stay;
	}
		

	// Update is called once per frame
	void Update()
	{

		if (_pickupState == PickupState.Kick)
		{
			StartCoroutine (countsetMessageBox(PickupState.Kick));
			Debug.Log("pickup state is kick. deduct money");
			_moneyComponent.DeductMoney(100);
			GetComponent<DriverSound>().PlayLosingSound();
			_pickupState = PickupState.Empty;
		}
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

			return;
		}


	
	}

	private void HandlePassengerState()
	{
		if (_pickupState != PickupState.Empty) return;

		Debug.Log("pickup");
		_peopleId = _objectConfig.ID.ToString();
		GetComponent<DriverSound>().PlayPickUpSound();
		_objectConfig.gameObject.SetActive(false);

		// taxi pick passenger.
		_pickupState = PickupState.Pick;
	}

	IEnumerator countsetMessageBox(PickupState _pickupS){
		
		if(MessageBoxMinus.transform.parent.gameObject.activeSelf)
			MessageBoxMinus.transform.parent.gameObject.SetActive (false);
		if(MessageBox_dontpick.transform.parent.gameObject.activeSelf)
			MessageBox_dontpick.transform.parent.gameObject.SetActive (false);
		if(MessageBoxPlus.transform.parent.gameObject.activeSelf)
			MessageBoxPlus.transform.parent.gameObject.SetActive (false);
		Debug.Log ("come");

		switch (_pickupS)
		{
		case PickupState.Pick:
			MessageBoxPlus.text = Plus_Message [Random.Range (0, Plus_Message.Length )];
			MessageBoxPlus.transform.parent.gameObject.SetActive (true);
			yield return new WaitForSecondsRealtime (2.5f);
			MessageBoxPlus.transform.parent.gameObject.SetActive (false);
			break;
		case PickupState.Empty:
			if(_CarController.GetCarVelocity() != 0){
				MessageBox_dontpick.text = dontpick_Message [Random.Range (0, dontpick_Message.Length)];
				MessageBox_dontpick.transform.parent.gameObject.SetActive (true);
				yield return new WaitForSecondsRealtime (2.5f);
				MessageBox_dontpick.transform.parent.gameObject.SetActive (false);
			}
			break;
		case PickupState.Kick:
			MessageBoxMinus.text = Minus_Message [Random.Range (0, Minus_Message.Length )];
			MessageBoxMinus.transform.parent.gameObject.SetActive (true);
			yield return new WaitForSecondsRealtime (2.5f);
			MessageBoxMinus.transform.parent.gameObject.SetActive (false);
			break;
		}

	}

	private void HandleBuildingState()
	{
		if (_pickupState != PickupState.Pick) return;

		Debug.Log("sent passenger");

		if (_peopleId == _objectConfig.ID.ToString()) {
			// taxi receive 100 baht.
			StartCoroutine (countsetMessageBox(PickupState.Pick));
			_moneyComponent.AddMoney (100);
			GetComponent<DriverSound> ().PlaySentSound ();

			// taxi has not passenger.
			_pickupState = PickupState.Empty;
			_peopleId = string.Empty;
		} else {
			StartCoroutine (countsetMessageBox(PickupState.Kick));
			Debug.Log("pickup state is kick. deduct money");
			_moneyComponent.DeductMoney(100);
			GetComponent<DriverSound>().PlayLosingSound();
			_pickupState = PickupState.Empty;
		}
	}
>>>>>>> 97cea60ffaf6f3ba45af5d5af009749c8af0d9d8
}