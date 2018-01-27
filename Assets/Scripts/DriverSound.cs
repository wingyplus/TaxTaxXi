using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverSound : MonoBehaviour {

	
	public AudioClip pickUpSound;
	public AudioClip sentSound;

	private bool picking;
	private bool sending;

	void Start()
	{
		picking = false;
		sending = false;
	}

	public void PlayPickUpSound() {
		GetComponent<AudioSource>().PlayOneShot(pickUpSound);
	}

	public void PlaySentSound() {
		GetComponent<AudioSource>().PlayOneShot(sentSound);
	}

}
