using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item {

	public string thrownby;

	public Armor(){
        this.heal = 5;
		this.itemName = "armor";
		this.itemType = "consumable";
	}
}
