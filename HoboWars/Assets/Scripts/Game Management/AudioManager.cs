using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{

	public AudioClip[] Sounds;

	public void playSound(string sound){

		switch(sound){

		case "Throw":
			AudioSource.PlayClipAtPoint (Sounds[0], transform.position, 2f);
			break;

		case "Apple":
			AudioSource.PlayClipAtPoint (Sounds[1], transform.position, 1f);
			break;

		case "PickUp":
			AudioSource.PlayClipAtPoint (Sounds[2], transform.position, 1f);
			break;

		case "OnHit":
			AudioSource.PlayClipAtPoint (Sounds[3], transform.position, 2f);
			break;

		case "Invalid":
			AudioSource.PlayClipAtPoint (Sounds[4], transform.position, 3f);
			break;

		case "Horse":
			AudioSource.PlayClipAtPoint (Sounds[5], transform.position, 1f);
			break;

		case "Win":
			AudioSource.PlayClipAtPoint (Sounds[6], transform.position, 3f);
			break;

		case "Armor":
			AudioSource.PlayClipAtPoint (Sounds[7], transform.position, 1f);
			break;
		}
	}
}
