using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    private float defaultHealth;
    public float currentHealth;
    private float defaultArmor;
    private float currentArmor;

    public Slider healthSlider;
    public Slider armorSlider;

    private bool isDead;

    void Awake() {
        defaultHealth = 100f;
        currentHealth = defaultHealth;

        defaultArmor = 0f;
        currentArmor = defaultArmor;

        isDead = false;
    }

    public void GetHit(float dmg) {
        if (currentArmor > 0) {
            DamageArmor(dmg);
			displayHealHit ("-"+dmg,Color.red);
        } else if (currentArmor <= 0) {
            currentArmor = 0;
            currentHealth -= dmg;
			displayHealHit ("-"+dmg,Color.red);
            healthSlider.value = currentHealth;
            if (currentHealth <= 0 && !isDead) {
                Die();
                isDead = true;
            }
        }
    }

    public void DamageArmor(float dmg) {

        if (dmg > currentArmor) {
            float leftover = dmg - currentArmor;
            currentArmor = 0;
            GetHit(leftover);
        } else {
            currentArmor -= dmg;

            if (currentArmor < 0) {
                currentArmor = 0;
            }
        }
        armorSlider.value = currentArmor;
    }

    public void GiveArmor(float armor) {
        currentArmor += armor;
        armorSlider.value = currentArmor;
		displayHealHit ("+"+armor,Color.white);
        if (currentArmor > 25) {
            currentArmor = 25f;
        }
    }

    public void Heal(float hp) {
        if ((currentHealth + hp) <= defaultHealth) {
            GetHit(-hp);
        } else {
            FullHeal();
        }
    }

    public void GetHeal(float hp) {
        if (currentHealth + hp >= defaultHealth) {
            currentHealth = defaultHealth;
            healthSlider.value = currentHealth;
			displayHealHit ("+"+hp,Color.green);
        } else {
            currentHealth += hp;
            healthSlider.value = currentHealth;
			displayHealHit ("+"+hp,Color.green);
        }
    }


    public void FullHeal() {
        GetHit(-(defaultHealth - currentHealth));
    }

    public void Die() {
        GameManager.finishGame(this.gameObject);
        StartCoroutine(GameManager.StopGame());
    }

    public IEnumerator Dot(int dotDamage, int totalSeconds, float intervalSeconds) {
        for (int i = 0; i < totalSeconds; i++) {
            yield return new WaitForSeconds(intervalSeconds);
            GetHit(dotDamage);
        }
    }

	public void displayHealHit(string value, Color color){

        StopCoroutine(closeHealHit());
		
		GameObject GUItext;

		if (this.tag == "player1") {
			GUItext = GameObject.Find ("HP-DMG1");
		} else {
			GUItext = GameObject.Find ("HP-DMG2");
		}

		GUItext.GetComponent<TextMesh> ().color = color;
		GUItext.GetComponent<TextMesh> ().text = value;

        StartCoroutine(closeHealHit());
        
    }

	public IEnumerator closeHealHit(){


		GameObject GUItext;

		if (this.tag == "player1") {
			GUItext = GameObject.Find ("HP-DMG1");
		} else {
			GUItext = GameObject.Find ("HP-DMG2");
		}

        yield return new WaitForSeconds(2);

        GUItext.GetComponent<TextMesh>().text = "";
    }
}
