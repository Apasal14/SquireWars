using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour {

    void Update() {

        if (this.gameObject.tag == "item_axe") {
            this.gameObject.transform.Rotate((-Vector3.forward * 900) * Time.deltaTime);
        } else if (this.gameObject.tag == "item_decapitatedHead") {
            this.gameObject.transform.Rotate((-Vector3.left * 900) * Time.deltaTime);
        } else if (this.gameObject.tag == "item_frostWand") {
            this.gameObject.transform.Rotate((Vector3.forward * 900) * Time.deltaTime);
        } else if (this.gameObject.tag == "item_deadRat") {
            this.gameObject.transform.Rotate((-Vector3.forward * 900) * Time.deltaTime);
        }
    }
}
