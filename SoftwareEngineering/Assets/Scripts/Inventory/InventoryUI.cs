using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour {

    public Transform ItemsParent;
    public GameObject InventoryUIPanel;

    Inventory inventory;

    InventorySlot[] Slots;


	 void Start ()
     {
         inventory = Inventory.Instance;
         inventory.OnItemChangedCallBack += UpdateUI;
     
         Slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
	 }
	
     void UpdateUI()
     {
         for(int i = 0; i < Slots.Length; i++)
         {
             if(i < inventory.Items.Count)
             {
                 Slots[i].AddItem(inventory.Items[i]);
             }
             else
             {
                 Slots[i].ClearSlot();
             }
         }
     }

	public void Close_OpenUI()
    {
        InventoryUIPanel.SetActive(!InventoryUIPanel.activeSelf);
    }


}
