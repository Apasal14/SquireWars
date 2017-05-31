using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Item {

	public string thrownby;

	public Axe(){
		this.damage = 35;
		this.itemName = "axe";
		this.itemType = "throwable";
	}
}
