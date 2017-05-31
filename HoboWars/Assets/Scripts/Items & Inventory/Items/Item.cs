using UnityEngine;

public class Item : MonoBehaviour {

	protected string itemName;
	protected string itemType;
    protected int damage;
    protected int dotDamage;
    protected int heal;
    protected float slow;
    public Sprite sprite;

	public string getItemName(){
		return itemName;
	}
	public string getItemType(){
		return itemType;
	}
	public int getDamage(){
		return damage;
	} 
    public int getHeal() {
        return heal;
    }
    public float getSlow() {
        return slow;
    }
    public int getDotDamage() {
        return dotDamage;
    }
}