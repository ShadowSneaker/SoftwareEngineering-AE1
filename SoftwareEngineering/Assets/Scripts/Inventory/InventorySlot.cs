using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    ItemScript item;
    public Image Icon;
    
    public Image ItemInfo;
    private Text[] InfoText;

    public bool infoclicked;
    

     public void AddItem(ItemScript newItem)
     {
         item = newItem;
         Icon.sprite = item.Image;
         Icon.enabled = true;

        InfoText = ItemInfo.GetComponentsInChildren<Text>();

         InfoText[0].text = "Name:" + item.ItemName;
        InfoText[1].text = "Description: " + item.Description;
     }

     public void ClearSlot()
     {
         item = null;
         Icon.sprite = null;
         Icon.enabled = false;
         
     }

     public void OnRemoveButton()
     {
         Inventory.Instance.RemoveItems(item);
     }

    public void UseItem()
    {
        // dont know what to add here yet
    }

    public void OnInfoClicked()
    {
        infoclicked = !infoclicked;
        InfoText = ItemInfo.GetComponentsInChildren<Text>();

        if (infoclicked)
        {
            ItemInfo.enabled = true;

            InfoText[0].enabled = true;
            InfoText[1].enabled = true;
        }
        else if(!infoclicked)
        {
            ItemInfo.enabled = false;

            InfoText[0].enabled = false;
            InfoText[1].enabled = false;
        }
    }

}
