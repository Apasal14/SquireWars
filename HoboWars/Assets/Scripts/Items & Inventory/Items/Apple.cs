using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : Item {

	public string thrownby;

	public Apple(){
        this.heal = 8;
		this.itemName = "apple";
		this.itemType = "consumable";
	}
}
