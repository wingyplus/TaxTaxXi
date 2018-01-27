using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ManSound : MonoBehaviour {

	public AudioClip pickUpSound;
	public AudioClip sentSound;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "car" && (other.GetComponent<Rigidbody2D>().velocity.x == 0)) {
			PlayPickUpSound();
		}
		
	}

	public void PlayPickUpSound() {
		GetComponent<AudioSource>().PlayOneShot(pickUpSound);
	}

	public void PlaySentSound() {
		GetComponent<AudioSource>().PlayOneShot(sentSound);
	}
}
