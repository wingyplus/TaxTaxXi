using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Man : MonoBehaviour {

	public AudioClip pickUpSound;
	public AudioClip sentSound;

	private bool picking;

	void Start()
	{
		picking = false;
	}

	void Update()
	{
		if( picking && !GetComponent<AudioSource>().isPlaying ){
			gameObject.SetActive(false);
			picking = false;
		}
	}
	public void GotPickedUp(){
		PlayPickUpSound();

        picking = true;
	}

	public void PlayPickUpSound() {
		GetComponent<AudioSource>().PlayOneShot(pickUpSound);
	}

	public void PlaySentSound() {
		GetComponent<AudioSource>().PlayOneShot(sentSound);
	}
}
