using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour {

    public Item[] items;

    //public GameObject GameManager;

    void Awake() {
        if (this.tag == "regularTrashCan") {
            items = new Item[4];
            items[0] = (Item)FindObjectOfType<Axe>();
            items[1] = (Item)FindObjectOfType<Apple>();
            items[2] = (Item)FindObjectOfType<Armor>();
            items[3] = (Item)FindObjectOfType<DeadRat>();

        } else if (this.tag == "goldenTrashCan") {
            items = new Item[2];
            items[0] = (Item)FindObjectOfType<FrostWand>();
            items[1] = (Item)FindObjectOfType<DecapitatedHead>();
        }
    }

    void OnTriggerEnter(Collider c) {

        if (c.tag == "player1") {
            GameManager.setPlayer1AtBin(this.gameObject);
        } else if (c.tag == "player2") {
            GameManager.setPlayer2AtBin(this.gameObject);
        }

    }

    void OnTriggerExit(Collider c) {

        if (c.tag == "player1") {
            GameManager.setPlayer1AtBin(null);
        } else if (c.tag == "player2") {
            GameManager.setPlayer2AtBin(null);
        }

    }

	public void displaySprite(Item item){

		GameObject GUIsprite = GameObject.Find (this.gameObject.name+"_SPRITE");

		GUIsprite.GetComponent<SpriteRenderer> ().sprite = item.sprite;

		StartCoroutine (closeSprite());
	}

	public IEnumerator closeSprite(){

		yield return new WaitForSeconds (1);

		GameObject GUIsprite = GameObject.Find (this.gameObject.name+"_SPRITE");

		GUIsprite.GetComponent<SpriteRenderer> ().sprite = null;
	}
}
