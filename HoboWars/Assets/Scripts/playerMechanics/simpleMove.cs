using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class simpleMove : MonoBehaviour {

	public float moveSpeed;
	public float v, h;
    public float slowFactor;


	private bool XboxController;
	private char JorK;
    public Animator anim;
	
	// Update is called once per frame
	void Update () {


		if (this.gameObject.tag == "player1") {
            // use k1 for keyboard and j1 for joystick
            v = CrossPlatformInputManager.GetAxis (JorK+"1_Vertical");
			h = -CrossPlatformInputManager.GetAxis (JorK+"1_Horizontal");
		} else {
			v = -CrossPlatformInputManager.GetAxis (JorK+"2_Vertical");
			h = CrossPlatformInputManager.GetAxis (JorK+"2_Horizontal");
		}

		transform.Translate (moveSpeed * slowFactor * v * Time.deltaTime, 0f,
            slowFactor * moveSpeed * h * Time.deltaTime);	

	}

    public IEnumerator slowPlayer(float newSlowFactor, int seconds) {
        slowFactor = newSlowFactor;
        yield return new WaitForSeconds(seconds);
        slowFactor = 1f;
    }

	public void setXboxController(bool x){

		this.XboxController = x;

		if (x) {
			JorK = 'j';
		} else {
			JorK = 'k';
		}
	}
}
