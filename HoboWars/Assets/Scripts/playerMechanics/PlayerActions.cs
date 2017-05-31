using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class PlayerActions : MonoBehaviour {

    public GameObject prefabAxe, prefabFrostwand, prefabDecapitatedHead, prefabDeadRat;
    public float speed = 1;
    LineRenderer line;
    public Vector3 angleOLD = new Vector3(0, 3f, 6);
    public Vector3 angle = new Vector3(0, 0, 1f);
    public float speedOfAngle = 0.15f;
	public float speedOfProjectile = 3f;



    public void throwItem(Item item) {
        if (item.getItemName() == "axe") {
            var newBall = Instantiate(prefabAxe, transform.position + (transform.forward), transform.rotation);
            newBall.GetComponent<Rigidbody>().useGravity = false;
            newBall.AddComponent<Axe>();
            newBall.GetComponent<Axe>().thrownby = this.gameObject.tag;
            newBall.transform.Rotate(-180, 90, -180);
            newBall.transform.Rotate(Vector3.forward * Time.deltaTime);
			newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5 * (transform.forward.z * speedOfProjectile)) * speed/*0,0,1 * (transform.forward.z*speedOfProjectile)) * speed*/;
            speed = 1;
            //line.SetVertexCount(0);
            //newBall.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * thrust);

            this.GetComponent<Inventory>().RemoveItem(item);
            print("you threw: " + item.getItemName());

        } else if (item.getItemName() == "frostwand") {
            var newBall = Instantiate(prefabFrostwand, transform.position + (transform.forward), transform.rotation);
            newBall.GetComponent<Rigidbody>().useGravity = false;
            newBall.AddComponent<FrostWand>();
            newBall.GetComponent<FrostWand>().thrownby = this.gameObject.tag;
			newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5 * (transform.forward.z * speedOfProjectile)) * speed/*angle.x, angle.y, angle.z * (transform.forward.z*speedOfProjectile)) * speed*/;
            speed = 1;
            //line.SetVertexCount(0);
            this.GetComponent<Inventory>().RemoveItem(item);
            print("you threw: " + item.getItemName());

        } else if (item.getItemName() == "decapitatedhead") {
            var newBall = Instantiate(prefabDecapitatedHead, transform.position + (transform.forward), transform.rotation);
            newBall.GetComponent<Rigidbody>().useGravity = false;
            newBall.AddComponent<DecapitatedHead>();
            newBall.GetComponent<DecapitatedHead>().thrownby = this.gameObject.tag;
            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5 * (transform.forward.z * speedOfProjectile)) * speed/*angle.x, angle.y, angle.z * (transform.forward.z*speedOfProjectile)) * speed*/;
            speed = 1;
            //line.SetVertexCount(0); 
            this.GetComponent<Inventory>().RemoveItem(item);
            //this.GetComponent<PlayerHealth>().FullHeal();
            print("you threw: " + item.getItemName());

        } else if (item.getItemName() == "deadrat") {
            var newBall = Instantiate(prefabDeadRat, transform.position + (transform.forward), transform.rotation);
            newBall.GetComponent<Rigidbody>().useGravity = false;
            newBall.AddComponent<DeadRat>();
            newBall.GetComponent<DeadRat>().thrownby = this.gameObject.tag;
            newBall.transform.Rotate(0, -90, 0);
            newBall.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5 * (transform.forward.z * speedOfProjectile)) * speed/*angle.x, angle.y, angle.z * (transform.forward.z*speedOfProjectile)) * speed*/;
            speed = 1;
            //line.SetVertexCount(0); 
            this.GetComponent<Inventory>().RemoveItem(item);
            print("you threw: " + item.getItemName());
        }
    }

    public void consumeItem(Item item) {
        //throw items

        if (item.getItemName() == "apple") {
            this.GetComponent<Inventory>().RemoveItem(item);
            this.GetComponent<PlayerHealth>().GetHeal(item.getHeal());
			GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Apple");
            print("you consumed: " + item.getItemName());

        } else if (item.getItemName() == "armor") {
            this.GetComponent<Inventory>().RemoveItem(item);
            this.GetComponent<PlayerHealth>().GiveArmor(item.getHeal());
			GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Armor");
            print("you consumed: " + item.getItemName());
        }
    }

    public void UseItem() {
        if (this.GetComponent<Inventory>().currentItem.getItemType() == "throwable") {
            throwItem(this.GetComponent<Inventory>().currentItem);
			GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Throw");
        } else if (this.GetComponent<Inventory>().currentItem.getItemType() == "consumable") {
            consumeItem(this.GetComponent<Inventory>().currentItem); ;
			//GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Consume");
        }
    }

    /*public void cycleThroughItems(){
		int indexnum = Array.IndexOf (this.GetComponent<Inventory> ().items, this.GetComponent<Inventory> ().currentItem);
		if (++indexnum < this.GetComponent<Inventory> ().items.Length) {
			this.GetComponent<Inventory> ().currentItem = this.GetComponent<Inventory> ().items [++indexnum];
		} else {
			this.GetComponent<Inventory> ().currentItem = this.GetComponent<Inventory> ().items [0];
		}
	}*/

    public void pickUpTrash(GameObject bin) {


        bool playerInventoryIsFull;

        if (this.GetComponent<Inventory>().currentItems == this.GetComponent<Inventory>().getNumItemSlots()) {
            playerInventoryIsFull = true;
        } else {
            playerInventoryIsFull = false;
        }

        if (playerInventoryIsFull) {
            //error, inventory full, give feedback
            print("Your inventory is full");
        } else {
            var itemToPickUp = bin.GetComponent<BinScript>().items[UnityEngine.Random.Range(0, bin.GetComponent<BinScript>().items.Length)];
            this.GetComponent<Inventory>().AddItem(itemToPickUp);
            print("You picked up " + itemToPickUp.getItemName());
			bin.GetComponent<BinScript> ().displaySprite (itemToPickUp);
			GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("PickUp");
        }
    }

    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = 70; // for example

        float timeDelta = 1.0f / initialVelocity.magnitude; // for example
        line = GetComponent<LineRenderer>();
        line.SetVertexCount(numSteps);
        line.SetWidth(0.04f, 0.04f);
        line.material = new Material(Shader.Find("Particles/Additive"));

        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; i++)
        {
            line.SetPosition(i, position);


            position += velocity * timeDelta + 0.5f * gravity * timeDelta * timeDelta;
            velocity += gravity * timeDelta;
        }
        //
    }
    public void charging()
    {
        speed += speedOfAngle;
        if (speed > 5) {
            speed = 5   ; 
        }
        //UpdateTrajectory(transform.position + (transform.forward), new Vector3(angle.x, angle.y, angle.z * transform.forward.z) * speed, Physics.gravity);

    }
    public float getspeed()
    {
        return speed;
    }
    public void setSpeed(float _speed)
    {
        speed = _speed;
    }
}
