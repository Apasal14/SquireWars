using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecapitatedHead : Item {

	public string thrownby;


	public DecapitatedHead(){
		this.damage = 0;
        this.dotDamage = 8;
		this.itemName = "decapitatedhead";
		this.itemType = "throwable";
	}
}
