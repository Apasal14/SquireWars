using UnityEngine;
using System;
public class Inventory : MonoBehaviour {
    public const int numItemSlots = 4;
    public Item[] items = new Item[numItemSlots];
    public int currentItems = 0;
    public Item currentItem;
	public int currentItemIndex ;
	//public bool isFirst = true;

    public Item[] possibleItems;

	public GameObject itemDisplay;

    public void AddItem(Item itemToAdd) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == null) {
                items[i] = itemToAdd;
                currentItems++;

				if (i == 0) {
					int found = 0;
					for(int j = 0; j < items.Length; j++){
						if (items [j] != null) {
							found++;
						}
					}
					if (found <= 1) {
						currentItem = items [i];
						currentItemIndex = i;
					} 
				}
				calculateAndUpdateDisplay ();
                return;
            }
        }
    }

    public void RemoveItem(Item itemToRemove) {
        for (int i = 0; i < items.Length; i++) {
            if (items[i] == itemToRemove) {
                items[i] = null;
                currentItems--;
				//if (currentItems > 1)
					//isFirst = true;
                updateCurrentItem();
                return;
            }
        }
    }


    public int getNumItemSlots() {
        return numItemSlots;
    }

    public void updateCurrentItem() {

        int nextusableitem = 0;

        for (int i = 0; i < items.Length; i++) {
            if (items[i] != null) {
                nextusableitem = i;
				currentItemIndex = i;
                break;
            }
        }

        if (items[nextusableitem] != null) {
            if (items[nextusableitem].getItemName() == "axe") {
                currentItem = possibleItems[0];
            } else if (items[nextusableitem].getItemName() == "frostwand") {
                currentItem = possibleItems[1];
            } else if (items[nextusableitem].getItemName() == "beer") { // WE DONT NEED BEER ITEM ANYMORE. REMOVE THIS
                currentItem = possibleItems[2];
            } else if (items[nextusableitem].getItemName() == "decapitatedhead") {
                currentItem = possibleItems[3];
            } else if (items[nextusableitem].getItemName() == "apple") {
                currentItem = possibleItems[4];
            } else if (items[nextusableitem].getItemName() == "armor") {
                currentItem = possibleItems[5];
            } else {
                currentItem = possibleItems[6];
            }

        } else {
            currentItem = null;
        }

		calculateAndUpdateDisplay ();

    }
		
	public void updateCurrentItemCycle2() {

		bool allarenull = true;
		bool otherItemExists = false;


		for (int i = 0; i < items.Length; i++) {
			if(items[i] != null){
				allarenull = false;
				break;
			}
		}

		if(!allarenull){
			for (int i = 0; i < items.Length; i++) {
				if(items[i] != null && items[i] != currentItem && i != currentItemIndex){
					otherItemExists = true;
					break;
				}
			}
		}


		if (otherItemExists) {  // first check that there is at least 1 item in the inventory
			checkAndUpdate();
		}

		calculateAndUpdateDisplay ();

	}

	void checkAndUpdate(){
		if (currentItemIndex+1 < items.Length) { //check that its safe to check next index
			if (items [currentItemIndex+1] != null) { // check next index, if not null, that the current item
				if(items [currentItemIndex+1] != currentItem){
					currentItem = items [currentItemIndex+1];
					currentItemIndex++;
				}else{
					currentItemIndex++;
					checkAndUpdate ();
				}
			}else { //if next index is null
				currentItemIndex++;
				checkAndUpdate ();
			}
		} else { // if its not safe to check next index, we are at array max, check first index
			currentItemIndex = -1;
			checkAndUpdate ();
		}
	}

	void calculateAndUpdateDisplay(){


		Item otherItem1 = null;
		Item otherItem2 = null;
		int otherItemIndex1 = -1;
		int otherItemIndex2 = -1;

		Item item0 = null;
		Item item1 = null;
		Item item2 = null;

		item0 = currentItem;


		if (item0 == null) {
			item1 = null;
			item2 = null;
		} else {
			for (int i = 0; i < items.Length; i++) {
				if(items[i] != null && items[i] != currentItem && i != currentItemIndex){
					otherItem1 = items [i];
					otherItemIndex1 = i;
					break;
				}
			}
		}

		if (otherItem1 != null){
			for (int i = 0; i < items.Length; i++) {
				if(items[i] != null && items[i] != currentItem && items[i] != otherItem1 && i != currentItemIndex && i != otherItemIndex1){
					otherItem2 = items [i];
					otherItemIndex2 = i;
					break;
				}
			}	
		}

		if (otherItem2 != null) {
			item1 = calculateItem1 (currentItem, currentItemIndex);
			item2 = calculateItem2 (currentItem, item1, currentItemIndex, otherItemIndex1);
		} else if (otherItem1 != null) {
			item1 = calculateItem1 (currentItem, currentItemIndex);
			item2 = null;
		} else {
			item1 = null;
			item2 = null;
		}

		itemDisplay.GetComponent<displayItems>().updateItems (item0, item1, item2);

	}

	Item calculateItem1(Item _currentItem, int _currentItemIndex){

		if (_currentItemIndex+1 < items.Length) { //check that its safe to check next index
			if (items [_currentItemIndex+1] != null) { // check next index, if not null, that the current item
				if(items [_currentItemIndex+1] != _currentItem){
					return items [_currentItemIndex+1];
				}else{
					_currentItemIndex++;
					return calculateItem1 (_currentItem, _currentItemIndex);
				}
			}else { //if next index is null
				_currentItemIndex++;
				return calculateItem1 (_currentItem, _currentItemIndex);
			}
		} else { // if its not safe to check next index, we are at array max, check first index
			_currentItemIndex = -1;
			return calculateItem1 (_currentItem, _currentItemIndex);
		}

	}

	Item calculateItem2(Item _currentItem, Item _otherItem1, int _currentItemIndex, int _otherItemIndex1){

		if (_currentItemIndex+1 < items.Length) { //check that its safe to check next index
			if (items [_currentItemIndex+1] != null) { // check next index, if not null, that the current item
				if(items [_currentItemIndex+1] != _currentItem && items [_currentItemIndex+1] != _otherItem1){
					return items [_currentItemIndex+1];
				}else{
					_currentItemIndex++;
					return calculateItem2 (_currentItem, _otherItem1, _currentItemIndex, _otherItemIndex1);
				}
			}else { //if next index is null
				_currentItemIndex++;
				return calculateItem2 (_currentItem, _otherItem1, _currentItemIndex, _otherItemIndex1);
			}
		} else { // if its not safe to check next index, we are at array max, check first index
			_currentItemIndex = -1;
			return calculateItem2 (_currentItem, _otherItem1, _currentItemIndex, _otherItemIndex1);
		}

	}
		
}

