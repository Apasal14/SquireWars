using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashMe : MonoBehaviour {

    private Color start;

    void Start() {
        start = this.GetComponent<SpriteRenderer>().material.color;
    }

    public IEnumerator Flash() {
        //print("start flassfsaf");
        for (int i = 0; i < 20; i++) {
            yield return new WaitForSeconds(0.02f);
            GetComponent<SpriteRenderer>().material.color = new Color(1,1,1,0);
            yield return new WaitForSeconds(0.02f);
            this.GetComponent<SpriteRenderer>().material.color = start;
            yield return new WaitForSeconds(0.06f);
        }
    }

    public IEnumerator FlashDot(int totalSeconds, int interval) {
        for (int i = 0; i < totalSeconds; i++) {
            yield return new WaitForSeconds(interval - 0.04f);
            this.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.04f);
            this.GetComponent<SpriteRenderer>().material.color = start;
        }
    }
}
