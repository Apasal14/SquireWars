using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnHit : MonoBehaviour {

    public void FlashPlayerOnHit() {
        foreach (SpriteRenderer c in GetComponentsInChildren<SpriteRenderer>()) {
            StartCoroutine(c.GetComponent<FlashMe>().Flash());
        }
    }

    public void FlashPlayerOnHitDot(int totalSconds, int interval) {
        foreach (SpriteRenderer c in GetComponentsInChildren<SpriteRenderer>()) {
            if (c.GetComponent<SpriteRenderer>() != null) {
                StartCoroutine(c.GetComponent<FlashMe>().FlashDot(totalSconds, interval));
            }
        }
    }
}

