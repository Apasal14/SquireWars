using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayItems : MonoBehaviour {


	public GameObject[] children;
	public Sprite defaultSprite;




	public void updateItems(Item item0, Item item1, Item item2){

		Debug.Log ("updating items");


		//current item
		if (item0 != null) {
			children [0].GetComponent<Image> ().sprite = item0.sprite;
			var tempColor = children [0].GetComponent<Image> ().color;
			tempColor.a = 1f;
			children [0].GetComponent<Image> ().color = tempColor;
		} else {
			var tempColor = children [0].GetComponent<Image> ().color;
			tempColor.a = 0f;
			children [0].GetComponent<Image> ().sprite = null;
			children [0].GetComponent<Image> ().color = tempColor;
		}
		//current item +1 
		if (item1 != null) {
			var tempColor = children [1].GetComponent<Image> ().color;
			tempColor.a = 1f;
			children [1].GetComponent<Image> ().sprite = item1.sprite;
			children [1].GetComponent<Image> ().color = tempColor;
		} else {
			var tempColor = children [1].GetComponent<Image> ().color;
			tempColor.a = 0f;
			children [1].GetComponent<Image> ().sprite = null;
			children [1].GetComponent<Image> ().color = tempColor;
		}

		//current item +2
		if (item2 != null) {
			var tempColor = children [2].GetComponent<Image> ().color;
			tempColor.a = 1f;
			children [2].GetComponent<Image> ().sprite = item2.sprite;
			children [2].GetComponent<Image> ().color = tempColor;
		} else {
			var tempColor = children [2].GetComponent<Image> ().color;
			tempColor.a = 0f;
			children [2].GetComponent<Image> ().sprite = null;
			children [2].GetComponent<Image> ().color = tempColor;
		}
	}
}
