using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour {

    private static InputManager instance = null;

    private static DateTime player1RegularBinCoolDown = DateTime.Now;
    private static DateTime player2RegularBinCoolDown = DateTime.Now;

	public simpleMove simpleMove1, simpleMove2;

	public bool XboxController;
	public static bool _XboxController;
    private static float animSpeed;

    // Use this for initialization
    void Awake() {

		_XboxController = XboxController;


        

        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);

		simpleMove1.setXboxController (_XboxController);
		simpleMove2.setXboxController (_XboxController);


    }

    public static void Player1CheckBinButton() {

		bool input;

		if (_XboxController) {
			input = CrossPlatformInputManager.GetButton ("j1_PickUp");
		} else {
			input = Input.GetKeyDown(KeyCode.K);
		}

         if (input && (DateTime.Now.Subtract(player1RegularBinCoolDown)).TotalSeconds > 1) {     // this is for keyboard control
            player1RegularBinCoolDown = DateTime.Now;
            if (GameManager.getPlayer1AtBin() != null) {
                GameManager.player1.GetComponent<PlayerActions>().pickUpTrash(GameManager.getPlayer1AtBin());
                GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetTrigger("pickup");
            }
        }
    }

    public static void Player2CheckBinButton() {

		bool input;

		if (_XboxController) {
			input = CrossPlatformInputManager.GetButton ("j2_PickUp");
		} else {
			input = Input.GetKeyDown(KeyCode.G);
		}
        // if player 1 presses K for bin pick up
         if (input && (DateTime.Now.Subtract(player2RegularBinCoolDown)).TotalSeconds > 1) {        // this is for keyboard control
            player2RegularBinCoolDown = DateTime.Now;
            if (GameManager.getPlayer2AtBin() != null) {
                GameManager.player2.GetComponent<PlayerActions>().pickUpTrash(GameManager.getPlayer2AtBin());
                GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetTrigger("pickup");
            }
        }
    }

    public static void Player1CheckThrowButton() {

		bool input, input2;

		if (_XboxController) {
			input = CrossPlatformInputManager.GetButton ("j1_Action");
			input2 = CrossPlatformInputManager.GetButtonUp ("j1_Action");
		} else {
			input = Input.GetKey(KeyCode.L);
			input2 = Input.GetKeyUp(KeyCode.L);
		}

        // if player 1 presses L to Throw 
         if (input)     // this is for keyboard control
        {
            //Charge the current shot
			if(GameManager.getPlayer1().GetComponent<Inventory>().currentItem != null &&
				GameManager.getPlayer1().GetComponent<Inventory>().currentItem.getItemType() == "throwable"){
           		
           	    	GameManager.getPlayer1().GetComponent<PlayerActions>().charging();
                GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetFloat("throwingSpeed", GameManager.getPlayer1().GetComponent<PlayerActions>().getspeed());
                GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetBool("isThrowing", true);
                //GameManager.getPlayer1().GetComponent<simpleMove>().anim.speed 




            }
        }
		if (input2){       // this is for keyboard control
        
            // Release the current shot
            if (GameManager.getPlayer1().GetComponent<Inventory>().currentItems > 0){
                GameManager.getPlayer1().GetComponent<PlayerActions>().UseItem();

                GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetFloat("throwingSpeed", 0);
                GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetBool("isThrowing", false);

                Debug.Log(GameManager.getPlayer1().GetComponent<Inventory>().currentItems);

            }
            else{
                print("Your inventory is empty");
                Debug.Log(GameManager.getPlayer1().GetComponent<Inventory>().currentItems);
				GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Invalid");
            }
        }
    }

    public static void Player2CheckThrowButton(){


		bool input, input2;

		if (_XboxController) {
			input = CrossPlatformInputManager.GetButton ("j2_Action");
			input2 = CrossPlatformInputManager.GetButtonUp ("j2_Action");
		} else {
			input = Input.GetKey(KeyCode.F);
			input2 = Input.GetKeyUp(KeyCode.F);
		}
        // if player 2 presses F for action

		if (input){     // this is for keyboard control        
            //Charge the current shot
			if (GameManager.getPlayer2 ().GetComponent<Inventory> ().currentItem != null &&
				GameManager.getPlayer2 ().GetComponent<Inventory> ().currentItem.getItemType () == "throwable") {
					GameManager.getPlayer2 ().GetComponent<PlayerActions> ().charging ();
                GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetFloat("throwingSpeed", GameManager.getPlayer2().GetComponent<PlayerActions>().getspeed());
                GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetBool("isThrowing", true);
            }

        }
		if (input2){ // this is for keyboard control
            // Release the current shot
            if (GameManager.getPlayer2().GetComponent<Inventory>().currentItems > 0){
                GameManager.getPlayer2().GetComponent<PlayerActions>().UseItem();

                GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetFloat("throwingSpeed", 0);
                GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetBool("isThrowing", false);

            }
            
        }
    }

    public static void Player1CheckMovement()
    {

        if (CrossPlatformInputManager.GetAxis("k1_Vertical") != 0 || CrossPlatformInputManager.GetAxis("k1_Horizontal") != 0 || CrossPlatformInputManager.GetAxis("j1_Horizontal") != 0 || CrossPlatformInputManager.GetAxis("j1_Vertical") != 0)
        {
            GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetBool("isMoving", true);
        }
        else
        {
            GameManager.getPlayer1().GetComponent<simpleMove>().anim.SetBool("isMoving", false);
        }
    }
    public static void Player2CheckMovement()
    {
        if (CrossPlatformInputManager.GetAxis("k2_Vertical") != 0 || CrossPlatformInputManager.GetAxis("k2_Horizontal") != 0 || CrossPlatformInputManager.GetAxis("j2_Horizontal") != 0 || CrossPlatformInputManager.GetAxis("j2_Vertical") != 0)
        {
            GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetBool("isMoving", true);
        }
        else
        {
            GameManager.getPlayer2().GetComponent<simpleMove>().anim.SetBool("isMoving", false);
        }
    }

    public static void Player1CheckCycleButton() {

		bool input;

		if (_XboxController) {
			input = CrossPlatformInputManager.GetButtonDown ("j1_CycleItems");
		} else {
			input = Input.GetKeyDown(KeyCode.M);
		}

         if (input) {        // this is for keyboard control
            GameManager.player1.GetComponent<Inventory>().updateCurrentItemCycle2();
        }
    }

    public static void Player2CheckCycleButton() {

		bool input;

		if (_XboxController) {
			input = CrossPlatformInputManager.GetButtonDown ("j2_CycleItems");
		} else {
			input = Input.GetKeyDown(KeyCode.V);
		}
		if (input) {        // this is for keyboard control
            GameManager.player2.GetComponent<Inventory>().updateCurrentItemCycle2();
        }
    }

}
