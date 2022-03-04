using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShopMenu", menuName = "ScriptableObjects/ItemsShop", order = 1)]
public class ItemsShop : ScriptableObject
{
    public string Title;
    public string Description;
    public int prize;
    
}
