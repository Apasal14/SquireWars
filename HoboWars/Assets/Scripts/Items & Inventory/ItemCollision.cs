using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {
	public bool firstcollision = true;
	public bool firstcollisionwithplayer = false;

    void OnCollisionEnter(Collision c){

		if (firstcollision){
			StartCoroutine (destroy());
			firstcollision = false;
		}
	}

	IEnumerator destroy(){
		
		yield return new WaitForSeconds (3);

		Destroy (this.gameObject);
	}
}
