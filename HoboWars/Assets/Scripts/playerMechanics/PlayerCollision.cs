using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    void OnCollisionEnter(Collision c) {

        if (this.gameObject.tag == "player1") {
			
		

            if (c.gameObject.tag == "item_axe" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<Axe>().thrownby == "player2") {
                    this.GetComponent<PlayerHealth>().GetHit(c.gameObject.GetComponent<Axe>().getDamage());  //replace with dynamic throwable item
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHit();
                }

            } else if (c.gameObject.tag == "item_deadRat" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<DeadRat>().thrownby == "player2") {
                    this.GetComponent<PlayerHealth>().GetHit(c.gameObject.GetComponent<DeadRat>().getDamage());  //replace with dynamic throwable item
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHit();
                }

            } else if (c.gameObject.tag == "item_frostWand" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<FrostWand>().thrownby == "player2") {
                    this.GetComponent<PlayerHealth>().GetHit(c.gameObject.GetComponent<FrostWand>().getDamage());  //replace with dynamic throwable item
                    StartCoroutine(this.GetComponent<simpleMove>().slowPlayer(c.gameObject.GetComponent<FrostWand>().getSlow(), 5));
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHit();
                }

            } else if (c.gameObject.tag == "horse" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                this.GetComponent<PlayerHealth>().GetHit(40);
                c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
                this.gameObject.GetComponent<Transform>().transform.position = (new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -7));
				GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Horse");
				GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");

                this.GetComponent<FlashOnHit>().FlashPlayerOnHit();

            } else if (c.gameObject.tag == "item_decapitatedHead" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<DecapitatedHead>().thrownby == "player2") {
                    StartCoroutine(this.GetComponent<PlayerHealth>().Dot(c.gameObject.GetComponent<DecapitatedHead>().getDotDamage(), 6, 2));
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHitDot(6,2);
                }
            }


        } else if (this.gameObject.tag == "player2") {
			

            if (c.gameObject.tag == "item_axe" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<Axe>().thrownby == "player1") {
                    this.GetComponent<PlayerHealth>().GetHit(c.gameObject.GetComponent<Axe>().getDamage());  //replace with dynamic throwable item
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHit();
                }

            } else if (c.gameObject.tag == "item_deadRat" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<DeadRat>().thrownby == "player1") {
                    this.GetComponent<PlayerHealth>().GetHit(c.gameObject.GetComponent<DeadRat>().getDamage());  //replace with dynamic throwable item
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHit();
                }

            } else if (c.gameObject.tag == "item_frostWand" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<FrostWand>().thrownby == "player1") {
                    this.GetComponent<PlayerHealth>().GetHit(c.gameObject.GetComponent<FrostWand>().getDamage());  //replace with dynamic throwable item
                    StartCoroutine(this.GetComponent<simpleMove>().slowPlayer(c.gameObject.GetComponent<FrostWand>().getSlow(), 5));
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHit();
                }

            } else if (c.gameObject.tag == "horse" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                this.GetComponent<PlayerHealth>().GetHit(40);
                c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
                this.gameObject.GetComponent<Transform>().transform.position = (new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 7));
				GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("Horse");
				GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                this.GetComponent<FlashOnHit>().FlashPlayerOnHit();

            } else if (c.gameObject.tag == "item_decapitatedHead" && !c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer) {
                if (c.gameObject.GetComponent<DecapitatedHead>().thrownby == "player1") { //replace with dynamic throwable item
                    StartCoroutine(this.GetComponent<PlayerHealth>().Dot(c.gameObject.GetComponent<DecapitatedHead>().getDotDamage(), 6, 2));
                    c.gameObject.GetComponent<ItemCollision>().firstcollisionwithplayer = true;
					GameObject.FindGameObjectWithTag ("manager").GetComponent<AudioManager> ().playSound ("OnHit");
                    this.GetComponent<FlashOnHit>().FlashPlayerOnHitDot(6, 2);
                }
            }
        }
    }
}

