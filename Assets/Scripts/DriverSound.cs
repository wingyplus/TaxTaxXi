using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DriverSound : MonoBehaviour {

	
	public AudioClip pickUpSound;
	public AudioClip sentSound;
	public AudioClip losingSound;

	public void PlayPickUpSound() {
		GetComponent<AudioSource>().PlayOneShot(pickUpSound);
	}

	public void PlaySentSound() {
		GetComponent<AudioSource>().PlayOneShot(sentSound);
	}

	public void PlayLosingSound() {
		GetComponent<AudioSource>().PlayOneShot(losingSound);
	}

}
