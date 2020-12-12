﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class conGift : MonoBehaviour
{
    public Text name;
    public Text text2;
    public void onClick()
    {
        Character_list character_List = new Character_list();
        for(int i = 0; i < character_List.charaters.Count; i++)
        {
            if (character_List.charaters[i].getName().Equals(name.text))
            {
                Dictionary<string, int> dc = character_List.charaters[i].getHobby();
                Debug.Log(dc.ToString());
                if (dc.ContainsKey(SendGift.shopItem.ItemName))
                {
                    character_List.charaters[i].addFaverable(dc[SendGift.shopItem.ItemName]);
                    text2.text = "I like it so much! " + string.Format("Faverable +%d", dc[SendGift.shopItem.ItemName]);
                }
                else
                {
                    character_List.charaters[i].addFaverable(-5);
                    text2.text = "OK, I have other things to do now " + string.Format("Faverable +%d", -5);
                }
                Listener.removeFromBag(SendGift.shopItem.ItemName);
                SendGift.shopItem = null;
            }
        }
        
    }
}
