﻿using System.Collections;
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

    
    public List<ItemScript> Items = new List<ItemScript>();
    public int space;
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;


   

      public bool AddItems (ItemScript item)
      {
          if(Items.Count >= space)
          {
              Debug.Log("No Room My good friend");
            return false;
          }
      
          Items.Add(item);
      
      
          if(OnItemChangedCallBack != null)
          {
              OnItemChangedCallBack.Invoke();
          }
        return true;
      }
      
      public void RemoveItems(ItemScript item)
      {
          Items.Remove(item);
      
          if (OnItemChangedCallBack != null)
          {
              OnItemChangedCallBack.Invoke();
          }
      }



}
