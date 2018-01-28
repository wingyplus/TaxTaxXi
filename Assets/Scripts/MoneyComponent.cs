using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyComponent : MonoBehaviour
{

	private double _amount;
	private Text _text;

	public void AddMoney(double amount)
	{
		_amount += amount;
	}

	public void ResetAmount()
	{
		_amount = 0;
	}

	public void DeductMoney(double amount)
	{
		_amount -= amount;
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
