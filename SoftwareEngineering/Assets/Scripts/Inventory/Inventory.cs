using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("More then one instance of inventory found");
        }

        Instance = this;
    }

    // uncomment once items have been done
    // public List<ItemScript> Items = new List<ItemScript>();
    public int space;
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;


    // uncomment once items have been done
    //  public bool AddItems (ItemScript item)
    //  {
    //      if(AddItems.Count >= space)
    //      {
    //          Debug.Log("No Room My good friend");
    //          return false
    //      }
    //  
    //      AddItems.Add(item);
    //  
    //  
    //      if(OnItemChangedCallBack != null)
    //      {
    //          OnItemChangedCallBack.Invoke();
    //      }
    //  
    //  }
    //  
    //  public void RemoveItems(ItemScipt item)
    //  {
    //      AddItems.Remove(item);
    //  
    //      if (OnItemChangedCallBack != null)
    //      {
    //          OnItemChangedCallBack.Invoke();
    //      }
    //  }



}
