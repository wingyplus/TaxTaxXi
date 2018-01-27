using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyComponent : MonoBehaviour
{

	private double _amount;
	private Text _text;
	public AudioSource no;
	public AudioSource ok;
	public AudioSource thankyou;

	public void AddMoney(double amount)
	{
		_amount += amount;
		thankyou.Play ();
	}

	public void ResetAmount()
	{
		_amount = 0;
	}

	public void DeductMoney(double amount)
	{
		_amount -= amount;
		no.Play ();
	}

	// Use this for initialization
	void Start ()
	{
		_text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update ()
	{
		_text.text = _amount.ToString();
	}
}
