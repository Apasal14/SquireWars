using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadRat : Item {

	public string thrownby;

	public DeadRat(){
		this.damage = 25;
		this.itemName = "deadrat";
		this.itemType = "throwable";
	}
}
