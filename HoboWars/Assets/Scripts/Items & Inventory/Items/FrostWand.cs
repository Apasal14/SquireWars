using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostWand : Item {

	public string thrownby;

	public FrostWand(){
		this.damage = 40;
        this.slow = 0.5f;
		this.itemName = "frostwand";
		this.itemType = "throwable";
	}
}
