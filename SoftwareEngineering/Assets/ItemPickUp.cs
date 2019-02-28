using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {

    public ItemScript Item;

	void Start ()
    {
		if(Item && Item.Image)
        {
            GetComponent<SpriteRenderer>().sprite = Item.Image;
        }
	}
	
	public void PickUp()
    {
        Inventory.Instance.AddItems(Item);

        Destroy(gameObject);

    }
	
}
